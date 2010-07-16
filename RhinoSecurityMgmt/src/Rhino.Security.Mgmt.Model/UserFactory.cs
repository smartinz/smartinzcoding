using Rhino.Security.Model;
namespace Rhino.Security.Mgmt.Model

{
	public class UserFactory : Nexida.Infrastructure.IFactory<User>
	{
		public User Create()
		{
			return new User();
		}
	}
}