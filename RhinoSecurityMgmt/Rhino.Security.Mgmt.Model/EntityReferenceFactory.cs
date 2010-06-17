using Rhino.Security.Model;
namespace Rhino.Security.Mgmt.Model

{
	public class EntityReferenceFactory : Nexida.Infrastructure.IFactory<EntityReference>
	{
		public EntityReference Create()
		{
			return new EntityReference();
		}
	}
}