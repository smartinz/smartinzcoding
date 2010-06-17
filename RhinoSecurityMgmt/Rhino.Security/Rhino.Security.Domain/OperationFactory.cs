namespace Rhino.Security.Model
{
	public class OperationFactory : Nexida.Infrastructure.IFactory<Operation>
	{
		public Operation Create()
		{
			return new Operation();
		}
	}
}