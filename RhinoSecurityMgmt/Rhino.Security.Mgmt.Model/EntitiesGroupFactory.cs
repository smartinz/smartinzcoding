using Rhino.Security.Model;
namespace Rhino.Security.Mgmt.Model
{
	public class EntitiesGroupFactory : Nexida.Infrastructure.IFactory<EntitiesGroup>
	{
		public EntitiesGroup Create()
		{
			return new EntitiesGroup();
		}
	}
}