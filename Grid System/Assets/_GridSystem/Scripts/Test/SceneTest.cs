using GridBuildSystem.Grid;
using GridBuildSystem.UI.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace GridBuildSystem.Testing
{
    public class SceneTest : MonoBehaviour
    {
        public BuildPanel buildPanel;
        public BuildPanelSettings buildPanelSettings;
        
        public GridSettings gridSettings;
        public Button testButton;
        private GridTestDrawer _gridTestDrawer;
        
        public Canvas _canvas;

        private void Awake()
        {
            var panel = Instantiate(buildPanel, _canvas.transform);
            panel.Construct(buildPanelSettings);

            panel.OnBuildingChoose += s => Debug.Log(s);
            panel.OnPlacementModeActive += () => Debug.Log("Placement Mode");
            panel.OnDestroyModeActive += () => Debug.Log("Destroy Mode");

            var grid = gridSettings.GetGrid<Cell>();
            _gridTestDrawer = new GridTestDrawer(grid, Color.white);
            
            testButton.onClick.AddListener(() => _gridTestDrawer.Draw());
        }

        public class Cell : IGridCell{}
    }
}