using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using GridBuildSystem.LoadSystem;
using GridBuildSystem.SaveSystem;
using GridBuildSystem.UI.Panels;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GridBuildSystem
{
    [CreateAssetMenu(fileName = "Grid Build System Settings", menuName = "ScriptableObjects/GridBuildSystem", order = 0)]
    public class GridBuildSystemSettings : ScriptableObject, IGridBuildSystemSettings
    {
        [Header("Grid Settings")]
        [SerializeField] private GridSettings _gridSettings;
        [SerializeField] private GridDrawerSettings _gridVisualSettings;
        
        [Header("UI Panels")]
        [SerializeField] private BuildPanelSettings _buildPanelSettings;
        [SerializeField] private TextPanelSettings _placePanelSettings;
        [SerializeField] private TextPanelSettings _destroyPanelSettings;
        
        [Header("Buildings")]
        [SerializeField] private BuildingSettings[] _buildingSettings;
        
        [Header("Input")]
        [SerializeField] private InputReader _inputReader;
        
        [field:Header("Save Settings")]
        [field: SerializeField] public SaveSystemTrigger SaveSystemGO { get; private set; }
        [field: SerializeField] public LoadSystemTrigger LoadSystemGO { get; private set; }
        [field: SerializeField]public XOREncryptorSettings XOREncryptorSettings { get; private set; }
        [field: SerializeField] public string SavePath { get; private set; } = "/save.json";
        
        public IGridSettings GridSettings => _gridSettings;
        public IGridDrawerSettings GridVisualSettings => _gridVisualSettings;
        public IBuildPanelSettings BuildPanelSettings => _buildPanelSettings;
        public ITextPanelSettings PlacementModePanelSettings => _placePanelSettings;
        public ITextPanelSettings DestroyModePanelSettings => _destroyPanelSettings;
        public IBuildingSettings[] BuildingSettings => _buildingSettings;
        public IInputReader InputReader => _inputReader;

        public IDeserializer GetDeserializer(IDecryptor decryptor) => new JSONDeserializer(decryptor, SavePath);
        public ISerializer GetSerializer(IEncryptor encryptor) => new JSONSerializer(encryptor, SavePath);
    }
}