using Rhino.Security.Model;
namespace Rhino.Security.Mgmt.Model

{
	public class EntityTypeFactory : Nexida.Infrastructure.IFactory<EntityType>
	{
		public EntityType Create()
		{
			return new EntityType();
		}
	}
}