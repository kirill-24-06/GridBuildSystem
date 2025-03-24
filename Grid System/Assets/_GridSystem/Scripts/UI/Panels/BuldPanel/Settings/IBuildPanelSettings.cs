namespace GridBuildSystem.UI.Panels
{
    public interface IBuildPanelSettings
    {
        BuildPanel Prefab { get; }
        IText PlacementModeText { get; }
        IText DestroyModeText { get; }
    }
}