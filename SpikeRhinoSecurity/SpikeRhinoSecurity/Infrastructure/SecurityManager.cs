using System.Web;
using Order;

namespace Order.Infrastructure
{
    public class SecurityManager
    {
        public void CheckPageSecurity(string securityToken)
        {
            if(CheckSecurity(securityToken))
            {
                return;
            }
//            _flashMessageManager.SetMessage(HttpContext.Current.User.Identity.IsAuthenticated ? "The current user does not have the privileges required to access the requested page. Login with a different user" : "To access the requested page you must login");
        }

        public bool CheckSecurity(string securityToken)
        {
			return false;// HttpContext.Current.User.IsInRole(securityToken);
        }
    }
}