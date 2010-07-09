using System.Web.Mvc;
using System.Collections.Generic;

namespace Rhino.Security.Mgmt.Controllers
{
	public class OperationController : Controller
	{
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Rhino.Security.Mgmt.Controllers.OperationController));
		private readonly Rhino.Security.Mgmt.Data.OperationRepository _repository;
		private readonly AutoMapper.IMappingEngine _mapper;
		private readonly Nexida.Infrastructure.IValidator _validator;
		private readonly Conversation.IConversation _conversation;
		private readonly Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Operation> _stringConverter;

		public OperationController(Conversation.IConversation conversation, AutoMapper.IMappingEngine mapper, Rhino.Security.Mgmt.Data.OperationRepository repository, Nexida.Infrastructure.IValidator validator, Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Operation> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Save(Rhino.Security.Mgmt.Dtos.OperationDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				var itemMapped = _mapper.Map<Rhino.Security.Mgmt.Dtos.OperationDto, Rhino.Security.Model.Operation>(item);
				Nexida.Infrastructure.Mvc.ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				Rhino.Security.Model.Operation itemToReturn = null;
				if (ModelState.IsValid)
				{
					var isNew = string.IsNullOrEmpty(item.StringId);
					if(isNew)
					{
						itemToReturn = _repository.Create(itemMapped);
					}
					if(!isNew)
					{
						itemToReturn = _repository.Update(itemMapped);
					}
					_conversation.Flush();
				}
				var itemToReturnDto = itemToReturn != null ? _mapper.Map<Rhino.Security.Model.Operation, Rhino.Security.Mgmt.Dtos.OperationDto>(itemToReturn) : null;
				return Json(new{
					item = itemToReturnDto,
					success = ModelState.IsValid,
					errors = Nexida.Infrastructure.Mvc.ValidationHelpers.BuildErrorDictionary(ModelState),
				});
			}
		}

		public ActionResult Load(string stringId)
		{
			using(_conversation.SetAsCurrent())
			{
				var item = _stringConverter.FromString(stringId);
				var itemDto = _mapper.Map<Rhino.Security.Model.Operation, Rhino.Security.Mgmt.Dtos.OperationDto>(item);
				return Json(itemDto);
			}
		}

		public void Delete(string stringId)
		{
			using(_conversation.SetAsCurrent())
			{
				var item = _stringConverter.FromString(stringId);
				_repository.Delete(item);
				_conversation.Flush();
			}
		}

				public ActionResult Search(System.Guid? id, string name, string comment, int start, int limit, string sort, string dir)
				{
					Log.DebugFormat("Search called");
					using(_conversation.SetAsCurrent())
					{
																		
						var set = _repository.Search(id, name, comment);
						var items = set.Skip(start).Take(limit).Sort(sort, dir == "ASC").AsEnumerable();
						var dtos = _mapper.Map<IEnumerable<Rhino.Security.Model.Operation>, Rhino.Security.Mgmt.Dtos.OperationDto[]>(items);
						return Json(new{ items = dtos, count = set.Count() });
					}
				}
				
	}
}