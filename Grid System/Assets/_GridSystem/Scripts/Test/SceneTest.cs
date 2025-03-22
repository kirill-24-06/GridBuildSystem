using System.Collections.Generic;
using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using GridBuildSystem.UI.Panels;
using GridBuildSystem.BuildSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace GridBuildSystem.Testing
{
    public class SceneTest : MonoBehaviour
    {
        public BuildPanel buildPanel;
        public BuildPanelSettings buildPanelSettings;
        
        public TextPanel textPanel;
        public TextPanelSettings textPanelSettings;
        
        public GridSettings gridSettings;
        public GridDrawerSettings gridDrawerSettings;
        private GridMode<IBuilding> _grid;
        private IDrawer _gridDrawer;
        
        public InputReader inputReader;
        public BuildingSettings[] testBuildings;
        public Transform Environment;
        
        private PlacementMode _placementMode;
        private DestroyMode _destroyMode;
        
        private Camera _camera;
        public Canvas canvas;


        private void Awake()
        {
            var buildPanel = Instantiate(this.buildPanel, canvas.transform);
            buildPanel.Construct(buildPanelSettings, testBuildings);
            
            var textPanel = Instantiate(this.textPanel, canvas.transform);
            textPanel.Construct(textPanelSettings);
            textPanel.Hide();
            
            _camera = Camera.main;
            
            _grid = gridSettings.GetGrid<IBuilding>();
            
            var gridTexture = Instantiate(gridDrawerSettings.TexturePrefab,gridSettings.GridOrigin,Quaternion.identity);
            gridTexture.transform.SetParent(Environment);
            gridTexture.SetActive(false);
            
            var gridDrawer = new GridDrawer(gridDrawerSettings,gridTexture);
            _gridDrawer = gridDrawer;

            var buildings = new Dictionary<string, IBuildingSettings>(testBuildings.Length);
            foreach (var buildingSettings in testBuildings)
            {
                buildings.Add(buildingSettings.BuildingName, buildingSettings);
            }

            var buildingsSpawner = new DefaultBuildingsSpawner(buildings, Environment);
            buildPanel.OnBuildingChoose += buildingsSpawner.OnBuildingChoose;
            
            _placementMode = new PlacementMode(_grid, _camera, inputReader,buildingsSpawner);
            buildPanel.OnPlacementModeActive += _placementMode.Enter;
            
            _destroyMode = new DestroyMode(_grid, _camera, inputReader, buildingsSpawner);
            buildPanel.OnDestroyModeActive += _destroyMode.Enter;

            _placementMode.OnEnter += () =>
            {
                _gridDrawer.Draw();
                buildPanel.Hide();
                textPanel.Show();
            };

            _placementMode.OnExit += () =>
            {
                buildPanel.Show();
                gridDrawer.Hide();
                textPanel.Hide();
            };
            
            _destroyMode.OnEnter += () =>
            {
                _gridDrawer.Draw();
                buildPanel.Hide();
                textPanel.Show();
            };

            _destroyMode.OnExit += () =>
            {
                buildPanel.Show();
                gridDrawer.Hide();
                textPanel.Hide();
            };
        }

        private void Start()
        {
            inputReader.EnableActionMap();
        }
    }
}