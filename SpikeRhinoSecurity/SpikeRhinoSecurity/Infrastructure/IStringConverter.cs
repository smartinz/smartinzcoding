namespace SpikeRhinoSecurity.Infrastructure
{
    public interface IStringConverter<T>
    {
        string ToString(T obj);
        T FromString(string str);
    }
}