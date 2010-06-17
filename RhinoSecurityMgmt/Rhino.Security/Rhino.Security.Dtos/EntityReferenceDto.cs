namespace Rhino.Security.Dtos
{
	public class EntityReferenceDto
	{
		public string StringId { get; set; }

		public System.Guid Id { get; set; }
				
		public System.Guid EntitySecurityKey { get; set; }
				
		// public Rhino.Security.Dtos.EntityTypeReferenceDto Type { get; set; }
				
	}
}