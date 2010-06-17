namespace Rhino.Security.Mgmt.Dtos
{
	public class EntityReferenceDto
	{
		public string StringId { get; set; }

		public System.Guid Id { get; set; }
				
		public System.Guid EntitySecurityKey { get; set; }
				
		// public Rhino.Security.Mgmt.Dtos.EntityTypeReferenceDto Type { get; set; }
				
	}
}