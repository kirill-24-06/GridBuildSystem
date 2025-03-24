namespace GridBuildSystem.BuildSystem
{
    public interface IValueReceiver<T>
    {
        void SetValue(T value);
    }
}