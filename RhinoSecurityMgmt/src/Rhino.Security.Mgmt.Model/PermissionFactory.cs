using Rhino.Security.Model;
namespace Rhino.Security.Mgmt.Model

{
	public class PermissionFactory : Nexida.Infrastructure.IFactory<Permission>
	{
		public Permission Create()
		{
			return new Permission();
		}
	}
}