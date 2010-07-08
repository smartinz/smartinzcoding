using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace Rhino.Security.Mgmt.Controllers
{
	public class UsersGroupController : Controller
	{
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Rhino.Security.Mgmt.Controllers.UsersGroupController));
		private readonly Rhino.Security.Mgmt.Data.UsersGroupRepository _repository;
		private readonly AutoMapper.IMappingEngine _mapper;
		private readonly Nexida.Infrastructure.IValidator _validator;
		private readonly Conversation.IConversation _conversation;
		private readonly Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.UsersGroup> _stringConverter;

		public UsersGroupController(Conversation.IConversation conversation, AutoMapper.IMappingEngine mapper, Rhino.Security.Mgmt.Data.UsersGroupRepository repository, Nexida.Infrastructure.IValidator validator, Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.UsersGroup> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Save(Rhino.Security.Mgmt.Dtos.UsersGroupDto item)
		{
			using (_conversation.SetAsCurrent())
			{
				Rhino.Security.Model.UsersGroup itemToReturn = null;
				var itemMapped = _mapper.Map<Rhino.Security.Mgmt.Dtos.UsersGroupDto, Rhino.Security.Model.UsersGroup>(item);
				Nexida.Infrastructure.Mvc.ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if (ModelState.IsValid)
				{
					var isNew = string.IsNullOrEmpty(item.StringId);
					if (isNew)
					{
						itemToReturn = _repository.Create(itemMapped);
					}
					if (!isNew)
					{
						itemToReturn = _repository.Update(itemMapped);
					}
					_conversation.Flush();
				}
				var itemToReturnDto = itemToReturn != null ? _mapper.Map<Rhino.Security.Model.UsersGroup, Rhino.Security.Mgmt.Dtos.UsersGroupDto>(itemToReturn) : null;
				return Json(new
				{
					item = itemToReturnDto,
					success = ModelState.IsValid,
					errors = Nexida.Infrastructure.Mvc.ValidationHelpers.BuildErrorDictionary(ModelState),
				});
			}
		}

		public ActionResult Load(string stringId)
		{
			using (_conversation.SetAsCurrent())
			{
				var item = _stringConverter.FromString(stringId);
				var itemDto = _mapper.Map<Rhino.Security.Model.UsersGroup, Rhino.Security.Mgmt.Dtos.UsersGroupDto>(item);
				return Json(itemDto);
			}
		}

		public void Delete(string stringId)
		{
			using (_conversation.SetAsCurrent())
			{
				var item = _stringConverter.FromString(stringId);
				_repository.Delete(item);
				_conversation.Flush();
			}
		}

		public ActionResult Search(string name, int start, int limit, string sort, string dir)
		{
			Log.DebugFormat("Search called");
			using (_conversation.SetAsCurrent())
			{
				var set = _repository.Search(name);
				var items = set.Skip(start).Take(limit).Sort(sort, dir == "ASC").AsEnumerable();
				var dtos = _mapper.Map<IEnumerable<Rhino.Security.Model.UsersGroup>, Rhino.Security.Mgmt.Dtos.UsersGroupDto[]>(items);
				return Json(new { items = dtos, count = set.Count() });
			}
		}

	}
}