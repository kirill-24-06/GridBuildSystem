using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using GridBuildSystem.UI.Panels;
using GridBuildSystem.BuildSystem;
using UnityEngine;

namespace GridBuildSystem.Testing
{
    public class SceneTest : MonoBehaviour
    {
        public BuildPanel buildPanel;
        public BuildPanelSettings buildPanelSettings;
        
        public TextPanel _textPanel;
        public TextPanelSettings textPanelSettings;
        
        public GridSettings gridSettings;
        private GridMode<IBuilding> grid;
        private GridTestDrawer _gridTestDrawer;
        
        public InputReader inputReader;
        public BuildingSettings testBuilding;
        
        private PlacementModeTest _placementModeTest;
        private DestroyModeTest _destroyModeTest;
        
        private Camera _camera;
        public Canvas _canvas;

        private void Awake()
        {
            var panel = Instantiate(buildPanel, _canvas.transform);
            panel.Construct(buildPanelSettings);
            
            var textPanel = Instantiate(_textPanel, _canvas.transform);
            textPanel.Construct(textPanelSettings);
            textPanel.Hide();
            
            _camera = Camera.main;
            
            panel.OnBuildingChoose += Debug.Log;

            grid = gridSettings.GetGrid<IBuilding>();
            _gridTestDrawer = new GridTestDrawer(grid, Color.white);
            
            _placementModeTest = new PlacementModeTest(grid, _camera, inputReader, testBuilding);
            panel.OnPlacementModeActive += _placementModeTest.Enter;
            
            _destroyModeTest = new DestroyModeTest(grid, _camera, inputReader);
            panel.OnDestroyModeActive += _destroyModeTest.Enter;

            _placementModeTest.OnEnter += () =>
            {
                _gridTestDrawer.Draw();
                panel.Hide();
                textPanel.Show();
            };

            _placementModeTest.OnExit += () =>
            {
                panel.Show();
                textPanel.Hide();
            };
            
            _destroyModeTest.OnEnter += () =>
            {
                _gridTestDrawer.Draw();
                panel.Hide();
                textPanel.Show();
            };

            _destroyModeTest.OnExit += () =>
            {
                panel.Show();
                textPanel.Hide();
            };
        }

        private void Start()
        {
            inputReader.EnableActionMap();
        }
    }
}