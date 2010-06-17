using Rhino.Security.Model;
namespace Rhino.Security.Mgmt.Model

{
	public class UsersGroupFactory : Nexida.Infrastructure.IFactory<UsersGroup>
	{
		public UsersGroup Create()
		{
			return new UsersGroup();
		}
	}
}