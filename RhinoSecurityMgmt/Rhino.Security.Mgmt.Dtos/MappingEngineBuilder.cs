using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;

namespace Rhino.Security.Mgmt.Dtos
{
	public static class MappingEngineBuilder
	{
		public static IMappingEngine Build()
		{
			Mapper.Reset();
			DomainToDto();
			DtoToDomain();
			Mapper.AssertConfigurationIsValid();
		    return Mapper.Engine;
		}

		private static void DomainToDto()
		{
			var sl = Microsoft.Practices.ServiceLocation.ServiceLocator.Current;

						Mapper.CreateMap<Rhino.Security.Model.EntitiesGroup, EntitiesGroupDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntitiesGroup>>().ToString(s)));
						Mapper.CreateMap<Rhino.Security.Model.EntitiesGroup, EntitiesGroupReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntitiesGroup>>().ToString(s)))
							.ForMember(d => d.Description, o => o.MapFrom(s => s.ToString()));
						
						Mapper.CreateMap<Rhino.Security.Model.EntityReference, EntityReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityReference>>().ToString(s)));
						Mapper.CreateMap<Rhino.Security.Model.EntityReference, EntityReferenceReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityReference>>().ToString(s)))
							.ForMember(d => d.Description, o => o.MapFrom(s => s.ToString()));
						
						Mapper.CreateMap<Rhino.Security.Model.EntityType, EntityTypeDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityType>>().ToString(s)));
						Mapper.CreateMap<Rhino.Security.Model.EntityType, EntityTypeReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityType>>().ToString(s)))
							.ForMember(d => d.Description, o => o.MapFrom(s => s.ToString()));
						
						Mapper.CreateMap<Rhino.Security.Model.Operation, OperationDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Operation>>().ToString(s)));
						Mapper.CreateMap<Rhino.Security.Model.Operation, OperationReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Operation>>().ToString(s)))
							.ForMember(d => d.Description, o => o.MapFrom(s => s.ToString()));
						
						Mapper.CreateMap<Rhino.Security.Model.Permission, PermissionDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Permission>>().ToString(s)));
						Mapper.CreateMap<Rhino.Security.Model.Permission, PermissionReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Permission>>().ToString(s)))
							.ForMember(d => d.Description, o => o.MapFrom(s => s.ToString()));
						
						Mapper.CreateMap<Rhino.Security.Model.UsersGroup, UsersGroupDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.UsersGroup>>().ToString(s)));
						Mapper.CreateMap<Rhino.Security.Model.UsersGroup, UsersGroupReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.UsersGroup>>().ToString(s)))
							.ForMember(d => d.Description, o => o.MapFrom(s => s.ToString()));
						
						Mapper.CreateMap<Rhino.Security.Model.User, UserDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.User>>().ToString(s)));
						Mapper.CreateMap<Rhino.Security.Model.User, UserReferenceDto>()
							.ForMember(d => d.StringId, o => o.MapFrom(s => sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.User>>().ToString(s)))
							.ForMember(d => d.Description, o => o.MapFrom(s => s.ToString()));
						
		}

		private static void DtoToDomain()
		{
			var sl = Microsoft.Practices.ServiceLocation.ServiceLocator.Current;

						Mapper.CreateMap<EntitiesGroupDto, Rhino.Security.Model.EntitiesGroup>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.EntitiesGroup>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntitiesGroup>>().FromString(s.StringId))
											.ForMember(d => d.Id, o => o.Ignore())
															.ForMember(d => d.Parent, o => o.Ignore())
															.ForMember(d => d.DirectChildren, o => o.Ignore())
															.ForMember(d => d.Entities, o => o.Ignore())
															.ForMember(d => d.AllChildren, o => o.Ignore())
															.ForMember(d => d.AllParents, o => o.Ignore())
											;
						Mapper.CreateMap<EntitiesGroupReferenceDto, Rhino.Security.Model.EntitiesGroup>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.EntitiesGroup>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntitiesGroup>>().FromString(s.StringId))
							.ForAllMembers(o => o.Ignore());
						
						Mapper.CreateMap<EntityReferenceDto, Rhino.Security.Model.EntityReference>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.EntityReference>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityReference>>().FromString(s.StringId))
											.ForMember(d => d.Id, o => o.Ignore())
															.ForMember(d => d.Type, o => o.Ignore())
											;
						Mapper.CreateMap<EntityReferenceReferenceDto, Rhino.Security.Model.EntityReference>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.EntityReference>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityReference>>().FromString(s.StringId))
							.ForAllMembers(o => o.Ignore());
						
						Mapper.CreateMap<EntityTypeDto, Rhino.Security.Model.EntityType>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.EntityType>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityType>>().FromString(s.StringId))
											.ForMember(d => d.Id, o => o.Ignore())
											;
						Mapper.CreateMap<EntityTypeReferenceDto, Rhino.Security.Model.EntityType>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.EntityType>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.EntityType>>().FromString(s.StringId))
							.ForAllMembers(o => o.Ignore());
						
						Mapper.CreateMap<OperationDto, Rhino.Security.Model.Operation>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.Operation>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Operation>>().FromString(s.StringId))
											.ForMember(d => d.Id, o => o.Ignore())
															.ForMember(d => d.Parent, o => o.Ignore())
															.ForMember(d => d.Children, o => o.Ignore())
											;
						Mapper.CreateMap<OperationReferenceDto, Rhino.Security.Model.Operation>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.Operation>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Operation>>().FromString(s.StringId))
							.ForAllMembers(o => o.Ignore());
						
						Mapper.CreateMap<PermissionDto, Rhino.Security.Model.Permission>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.Permission>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Permission>>().FromString(s.StringId))
											.ForMember(d => d.Id, o => o.Ignore())
															.ForMember(d => d.UsersGroup, o => o.Ignore())
															.ForMember(d => d.User, o => o.Ignore())
											;
						Mapper.CreateMap<PermissionReferenceDto, Rhino.Security.Model.Permission>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.Permission>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.Permission>>().FromString(s.StringId))
							.ForAllMembers(o => o.Ignore());
						
						Mapper.CreateMap<UsersGroupDto, Rhino.Security.Model.UsersGroup>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.UsersGroup>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.UsersGroup>>().FromString(s.StringId))
											.ForMember(d => d.Id, o => o.Ignore())
															.ForMember(d => d.Parent, o => o.Ignore())
															.ForMember(d => d.AllParents, o => o.Ignore())
															.ForMember(d => d.Users, o => o.Ignore())
															.ForMember(d => d.AllChildren, o => o.Ignore())
															.ForMember(d => d.DirectChildren, o => o.Ignore())
											;
						Mapper.CreateMap<UsersGroupReferenceDto, Rhino.Security.Model.UsersGroup>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.UsersGroup>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.UsersGroup>>().FromString(s.StringId))
							.ForAllMembers(o => o.Ignore());
						
						Mapper.CreateMap<UserDto, Rhino.Security.Model.User>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.User>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.User>>().FromString(s.StringId))
											.ForMember(d => d.Id, o => o.Ignore())
											.ForMember(d => d.Groups, o => o.Ignore())
											;
						Mapper.CreateMap<UserReferenceDto, Rhino.Security.Model.User>()
							.ConstructUsing(s => string.IsNullOrEmpty(s.StringId) ? sl.GetInstance<Nexida.Infrastructure.IFactory<Rhino.Security.Model.User>>().Create() : sl.GetInstance<Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.User>>().FromString(s.StringId))
							.ForAllMembers(o => o.Ignore());
						
		}
	}
}