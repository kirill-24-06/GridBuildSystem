using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.UI.Panels;
using UnityEngine;

namespace GridBuildSystem
{
    public class BuildPanelInstaller : IInstaller
    {
        private readonly IBuildPanelSettings _settings;
        private readonly IBuildingUIData[] _buildingUIData;
        private readonly Canvas _ui;

        public IBuildPanel BuildPanel { get; private set; }

        public BuildPanelInstaller(IBuildPanelSettings settings, IBuildingUIData[] buildingUIData, Canvas ui)
        {
            _settings = settings;
            _buildingUIData = buildingUIData;
            _ui = ui;
        }

        public void Install()
        {
            var panel = Object.Instantiate(_settings.Prefab, _ui.transform);
            panel.Construct(_settings, _buildingUIData);

            BuildPanel = panel;
        }
    }
}