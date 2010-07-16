using Rhino.Security.Model;
namespace Rhino.Security.Mgmt.Model

{
	public class OperationFactory : Nexida.Infrastructure.IFactory<Operation>
	{
		public Operation Create()
		{
			return new Operation();
		}
	}
}