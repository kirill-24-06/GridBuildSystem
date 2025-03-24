using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using GridBuildSystem.LoadSystem;
using GridBuildSystem.SaveSystem;
using GridBuildSystem.UI.Panels;

namespace GridBuildSystem
{
    public interface IGridBuildSystemSettings
    {
        string SavePath { get; }
        SaveSystemTrigger SaveSystemGO { get; }
        LoadSystemTrigger LoadSystemGO { get; }
        IGridSettings GridSettings { get; }
        IGridDrawerSettings GridVisualSettings { get; }
        IBuildPanelSettings BuildPanelSettings { get; }
        IBuildingSettings[] BuildingSettings { get; }
        ITextPanelSettings PlacementModePanelSettings { get; }
        ITextPanelSettings DestroyModePanelSettings { get; }
        IInputReader InputReader { get; }
        XOREncryptorSettings XOREncryptorSettings { get; }
        ISerializer GetSerializer(IEncryptor encryptor);
        IDeserializer GetDeserializer(IDecryptor decryptor);
    }
}