namespace Rhino.Security.Model
{
	public class EntityReferenceFactory : Nexida.Infrastructure.IFactory<EntityReference>
	{
		public EntityReference Create()
		{
			return new EntityReference();
		}
	}
}