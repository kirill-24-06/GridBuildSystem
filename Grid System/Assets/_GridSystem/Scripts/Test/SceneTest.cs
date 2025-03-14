using GridBuildSystem.Grid;
using GridBuildSystem.UI.Panels;
using UnityEngine;

namespace GridBuildSystem.Testing
{
    public class SceneTest : MonoBehaviour
    {
        public BuildPanel buildPanel;
        public BuildPanelSettings buildPanelSettings;

        private GridTestDrawer _gridTestDrawer;

        public Canvas _canvas;

        private void Awake()
        {
            var panel = Instantiate(buildPanel, _canvas.transform);
            panel.Construct(buildPanelSettings);

            panel.OnBuildingChoose += s => Debug.Log(s);
            panel.OnPlacementModeActive += () => Debug.Log("Placement Mode");
            panel.OnDestroyModeActive += () => Debug.Log("Destroy Mode");
        }
    }
}