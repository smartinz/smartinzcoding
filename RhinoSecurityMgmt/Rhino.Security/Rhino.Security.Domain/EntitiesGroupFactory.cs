namespace Rhino.Security.Model
{
	public class EntitiesGroupFactory : Nexida.Infrastructure.IFactory<EntitiesGroup>
	{
		public EntitiesGroup Create()
		{
			return new EntitiesGroup();
		}
	}
}