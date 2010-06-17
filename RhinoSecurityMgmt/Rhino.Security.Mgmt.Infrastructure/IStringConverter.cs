namespace Nexida.Infrastructure
{
    public interface IStringConverter<T>
    {
        string ToString(T obj);
        T FromString(string str);
    }
}