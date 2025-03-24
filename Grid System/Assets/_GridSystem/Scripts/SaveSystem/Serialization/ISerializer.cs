namespace GridBuildSystem.SaveSystem
{
    public interface ISerializer
    {
        void Serialize(ISaveData data);
    }
}