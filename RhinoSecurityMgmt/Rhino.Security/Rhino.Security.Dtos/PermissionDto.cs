namespace Rhino.Security.Dtos
{
	public class PermissionDto
	{
		public string StringId { get; set; }

		public System.Guid Id { get; set; }
				
		public System.Guid? EntitySecurityKey { get; set; }
				
		public bool Allow { get; set; }
				
		public int Level { get; set; }
				
		public string EntityTypeName { get; set; }
				
		public Rhino.Security.Dtos.EntitiesGroupReferenceDto EntitiesGroup { get; set; }
				
		public Rhino.Security.Dtos.OperationReferenceDto Operation { get; set; }
				
		// public Rhino.Security.Dtos.UsersGroupReferenceDto UsersGroup { get; set; }
				
		// public Rhino.Security.Dtos.UserReferenceDto User { get; set; }
				
	}
}