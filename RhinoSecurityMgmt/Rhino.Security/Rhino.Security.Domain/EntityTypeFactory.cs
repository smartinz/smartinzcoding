namespace Rhino.Security.Model
{
	public class EntityTypeFactory : Nexida.Infrastructure.IFactory<EntityType>
	{
		public EntityType Create()
		{
			return new EntityType();
		}
	}
}