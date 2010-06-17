namespace Nexida.Infrastructure
{
	public interface IFactory<T>
	{
		T Create();
	}
}