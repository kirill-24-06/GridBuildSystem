namespace GridBuildSystem.SaveSystem
{
    public interface ISerializer
    {
        void Serialize<T>(T data);
    }
}