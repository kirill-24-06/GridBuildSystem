namespace GridBuildSystem.UI.Panels
{
    public interface ITextPanelSettings
    {
        TextPanel Prefab { get; }
        TextSettings LeftTextSettings { get; }
        TextSettings RightTextSettings { get; }
    }
}