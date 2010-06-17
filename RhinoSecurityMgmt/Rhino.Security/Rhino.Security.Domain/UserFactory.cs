namespace Rhino.Security.Model
{
	public class UserFactory : Nexida.Infrastructure.IFactory<User>
	{
		public User Create()
		{
			return new User();
		}
	}
}