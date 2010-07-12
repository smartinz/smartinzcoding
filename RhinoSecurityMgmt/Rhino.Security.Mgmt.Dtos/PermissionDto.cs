namespace Rhino.Security.Mgmt.Dtos
{
	public class PermissionDto
	{
		public string StringId { get; set; }

		public System.Guid Id { get; set; }
				
		public System.Guid? EntitySecurityKey { get; set; }
				
		public bool Allow { get; set; }
				
		public int Level { get; set; }
				
		public string EntityTypeName { get; set; }
				
		//public Rhino.Security.Mgmt.Dtos.EntitiesGroupReferenceDto EntitiesGroup { get; set; }
				
		public Rhino.Security.Mgmt.Dtos.OperationReferenceDto Operation { get; set; }
				
		public Rhino.Security.Mgmt.Dtos.UsersGroupReferenceDto UsersGroup { get; set; }
				
		public Rhino.Security.Mgmt.Dtos.UserReferenceDto User { get; set; }
	}
}