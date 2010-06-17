namespace Rhino.Security.Model
{
	public class UsersGroupFactory : Nexida.Infrastructure.IFactory<UsersGroup>
	{
		public UsersGroup Create()
		{
			return new UsersGroup();
		}
	}
}