using System.Collections.Generic;
using GridBuildSystem.BuildSystem;
using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.SaveSystem;
using UnityEngine;

namespace GridBuildSystem
{
    public class MainSceneBootstrap : MonoBehaviour
    {
        [SerializeField] private GridBuildSystemSettings _settings;
        [SerializeField] private Transform _parentTransform;
        [SerializeField] private Canvas _canvas;

        private GridInstaller _gridInstaller;
        private BuildPanelInstaller _buildPanelInstaller;
        private readonly TextPanelInstaller[] _textPanelInstallers = new TextPanelInstaller[2];
        private GridBuildSystemInstaller _buildSystemInstaller;
        private SaveSystemInstaller _saveSystemInstaller;
        private LoadSystemInstaller _loadSystemInstaller;

        private void Awake()
        {
            var encryptor = new XOREncryptor(_settings.XOREncryptorSettings);

            var buildingsSaveDataHolder = new BuildingsSaveDataHolder();
            
            var buildingSettings = new Dictionary<string, IBuildingSettings>(_settings.BuildingSettings.Length);
            foreach (var settings in _settings.BuildingSettings)
            {
                buildingSettings.Add(settings.BuildingName, settings);
            }
            
            var spawner = new DefaultBuildingsSpawner(buildingSettings, buildingsSaveDataHolder, _parentTransform);

            _gridInstaller = new GridInstaller(_settings.GridSettings, _settings.GridVisualSettings, _parentTransform);

            _buildPanelInstaller =
                new BuildPanelInstaller(_settings.BuildPanelSettings, _settings.BuildingSettings, _canvas);
            _textPanelInstallers[0] = new TextPanelInstaller(_settings.PlacementModePanelSettings, _canvas);
            _textPanelInstallers[1] = new TextPanelInstaller(_settings.DestroyModePanelSettings, _canvas);

            _buildSystemInstaller = new GridBuildSystemInstaller(_settings, _gridInstaller, _buildPanelInstaller,
                _textPanelInstallers, buildingsSaveDataHolder, _parentTransform);

            _saveSystemInstaller = new SaveSystemInstaller(_settings, buildingsSaveDataHolder, encryptor);
            _loadSystemInstaller =
                new LoadSystemInstaller(_settings, encryptor, spawner, spawner,_gridInstaller);
            
            Install();
        }

        private void Start()
        {
            _settings.InputReader.EnableActionMap();
            Destroy(gameObject);
        }

        private void Install()
        {
            _gridInstaller.Install();
            
            _buildPanelInstaller.Install();
            _textPanelInstallers[0].Install();
            _textPanelInstallers[1].Install();
            
            _buildSystemInstaller.Install();
            
            _saveSystemInstaller.Install();
            _loadSystemInstaller.Install();
        }
    }
}