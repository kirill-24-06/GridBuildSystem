using System.Collections.Generic;
using GridBuildSystem.BuildSystem;
using GridBuildSystem.BuildSystem.Buildings;
using UnityEngine;

namespace GridBuildSystem
{
    public class GridBuildSystemInstaller : IInstaller
    {
        private readonly GridBuildSystemSettings _settings;
        private readonly Transform _parentTransform;

        private readonly GridInstaller _gridInstaller;
        private readonly BuildPanelInstaller _buildPanelInstaller;
        private readonly TextPanelInstaller[] _textPanelInstallers;

        private readonly IBuildingsSaveDataHolder _buildingsSaveDataHolder;

        private readonly Dictionary<string, IBuildingSettings> _buildingSettings;

        public GridBuildSystemInstaller(GridBuildSystemSettings settings, GridInstaller gridInstaller,
            BuildPanelInstaller buildPanelInstaller, TextPanelInstaller[] textPanelInstallers,
            IBuildingsSaveDataHolder buildingsSaveDataHolder,
            Transform parentTransform)
        {
            _settings = settings;
            _parentTransform = parentTransform;

            _buildingsSaveDataHolder = buildingsSaveDataHolder;

            _gridInstaller = gridInstaller;
            _buildPanelInstaller = buildPanelInstaller;
            _textPanelInstallers = textPanelInstallers;

            _buildingSettings = new Dictionary<string, IBuildingSettings>();
            foreach (var building in _settings.BuildingSettings)
            {
                _buildingSettings.Add(building.BuildingName, building);
            }
        }

        public void Install()
        {
            var grid = _gridInstaller.Grid;
            var gridDrawer = _gridInstaller.GridDrawer;
            var camera = Camera.main;

            var buildPanel = _buildPanelInstaller.BuildPanel;
            var placePanel = _textPanelInstallers[0].TextPanel;
            var destroyPanel = _textPanelInstallers[1].TextPanel;

            var spawner = new DefaultBuildingsSpawner(_buildingSettings, _buildingsSaveDataHolder, _parentTransform);

            var placementMode = new PlacementMode(grid, spawner, _settings.InputReader, camera);
            var destroyMode = new DestroyMode(grid, spawner, _settings.InputReader, camera);

            buildPanel.OnBuildingChoose += spawner.SetValue;
            buildPanel.OnPlacementModeActive += placementMode.Enter;
            buildPanel.OnDestroyModeActive += destroyMode.Enter;

            placementMode.OnEnter += () =>
            {
                gridDrawer.Draw();
                buildPanel.Hide();
                placePanel.Show();
            };

            placementMode.OnExit += () =>
            {
                gridDrawer.Hide();
                buildPanel.Show();
                placePanel.Hide();
            };

            destroyMode.OnEnter += () =>
            {
                gridDrawer.Draw();
                buildPanel.Hide();
                destroyPanel.Show();
            };

            destroyMode.OnExit += () =>
            {
                gridDrawer.Hide();
                buildPanel.Show();
                destroyPanel.Hide();
            };
        }
    }
}