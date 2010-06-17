using System.Web.Mvc;
using System.Collections.Generic;

namespace Rhino.Security.Mgmt.Controllers
{
	public class EntityReferenceController : Controller
	{
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Rhino.Security.Mgmt.Controllers.EntityReferenceController));
		private readonly Rhino.Security.Mgmt.Data.EntityReferenceRepository _repository;
		private readonly AutoMapper.IMappingEngine _mapper;
		private readonly Nexida.Infrastructure.IValidator _validator;
		private readonly Conversation.IConversation _conversation;
		private readonly Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityReference> _stringConverter;

		public EntityReferenceController(Conversation.IConversation conversation, AutoMapper.IMappingEngine mapper, Rhino.Security.Mgmt.Data.EntityReferenceRepository repository, Nexida.Infrastructure.IValidator validator, Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityReference> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Save(Rhino.Security.Mgmt.Dtos.EntityReferenceDto item)
		{
			using(_conversation.SetAsCurrent())
			{
				var itemMapped = _mapper.Map<Rhino.Security.Mgmt.Dtos.EntityReferenceDto, Rhino.Security.Model.EntityReference>(item);
				Nexida.Infrastructure.Mvc.ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if (ModelState.IsValid)
				{
					var isNew = string.IsNullOrEmpty(item.StringId);
					if(isNew)
					{
						_repository.Create(itemMapped);
					}
					if(!isNew)
					{
						_repository.Update(itemMapped);
					}
					_conversation.Flush();
				}
				return Json(new{
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
				var itemDto = _mapper.Map<Rhino.Security.Model.EntityReference, Rhino.Security.Mgmt.Dtos.EntityReferenceDto>(item);
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

				public ActionResult Search(System.Guid? id, System.Guid? entitySecurityKey, int start, int limit, string sort, string dir)
				{
					Log.DebugFormat("Search called");
					using(_conversation.SetAsCurrent())
					{
														
						var set = _repository.Search(id, entitySecurityKey);
						var items = set.Skip(start).Take(limit).Sort(sort, dir == "ASC").AsEnumerable();
						var dtos = _mapper.Map<IEnumerable<Rhino.Security.Model.EntityReference>, Rhino.Security.Mgmt.Dtos.EntityReferenceDto[]>(items);
						return Json(new{ items = dtos, count = set.Count() });
					}
				}
				
	}
}