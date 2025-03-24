using GridBuildSystem.UI.Panels;
using UnityEngine;

namespace GridBuildSystem
{
    public class TextPanelInstaller : IInstaller
    {
        private readonly ITextPanelSettings _settings;
        private readonly Canvas _ui;

        public IPanel TextPanel { get; private set; }

        public TextPanelInstaller(ITextPanelSettings settings, Canvas ui)
        {
            _settings = settings;
            _ui = ui;
        }

        public void Install()
        {
            var panel = Object.Instantiate(_settings.Prefab, _ui.transform);
            panel.Construct(_settings);
            panel.Hide();

            TextPanel = panel;
        }
    }
}