using System.Web.Mvc;
using System.Collections.Generic;
using Rhino.Security.Model;
using Rhino.Security.Mgmt.Dtos;

namespace Rhino.Security.Mgmt.Controllers
{
	public class PermissionController : Controller
	{
		private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(Rhino.Security.Mgmt.Controllers.PermissionController));
		private readonly Rhino.Security.Mgmt.Data.PermissionRepository _repository;
		private readonly AutoMapper.IMappingEngine _mapper;
		private readonly Nexida.Infrastructure.IValidator _validator;
		private readonly Conversation.IConversation _conversation;
		private readonly Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Permission> _stringConverter;

		public PermissionController(Conversation.IConversation conversation, AutoMapper.IMappingEngine mapper, Rhino.Security.Mgmt.Data.PermissionRepository repository, Nexida.Infrastructure.IValidator validator, Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Permission> stringConverter)
		{
			_conversation = conversation;
			_mapper = mapper;
			_repository = repository;
			_validator = validator;
			_stringConverter = stringConverter;
		}

		public ActionResult Save(Rhino.Security.Mgmt.Dtos.PermissionDto item)
		{
			using (_conversation.SetAsCurrent())
			{
				Permission permissionToReturn = null;
				var itemMapped = _mapper.Map<Rhino.Security.Mgmt.Dtos.PermissionDto, Rhino.Security.Model.Permission>(item);
				Nexida.Infrastructure.Mvc.ValidationHelpers.AddErrorsToModelState(ModelState, _validator.Validate(itemMapped), "item");
				if (ModelState.IsValid)
				{
					permissionToReturn = _repository.Create(itemMapped);
				}
				PermissionDto permissionToReturnDto = permissionToReturn != null ? _mapper.Map<Permission, PermissionDto>(permissionToReturn) : null;
				return Json(new
				{
					item = permissionToReturnDto,
					success = ModelState.IsValid,
					errors = Nexida.Infrastructure.Mvc.ValidationHelpers.BuildErrorDictionary(ModelState),
				});
			}
		}

		public ActionResult Load(string operationName)
		{
			using (_conversation.SetAsCurrent())
			{
				var items = _repository.ReadByOperation(operationName);
				var dtos = _mapper.Map<Rhino.Security.Model.Permission[], Rhino.Security.Mgmt.Dtos.PermissionDto[]>(items);
				return Json(new { items = dtos, count = dtos.Length });
			}
		}
	}
}