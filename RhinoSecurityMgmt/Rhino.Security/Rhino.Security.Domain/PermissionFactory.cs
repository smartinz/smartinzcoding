namespace Rhino.Security.Model
{
	public class PermissionFactory : Nexida.Infrastructure.IFactory<Permission>
	{
		public Permission Create()
		{
			return new Permission();
		}
	}
}