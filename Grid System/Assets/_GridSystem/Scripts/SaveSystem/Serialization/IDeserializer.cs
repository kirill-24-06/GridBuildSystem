namespace GridBuildSystem.LoadSystem
{
    public interface IDeserializer
    {
        bool Deserialize<T>(out T data);
    }
}