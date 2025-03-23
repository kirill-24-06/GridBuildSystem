<<<<<<< Updated upstream
=======
using System;
using System.Collections.Generic;
using GridBuildSystem.BuildSystem.Buildings;
>>>>>>> Stashed changes
using GridBuildSystem.Grid;
using GridBuildSystem.UI.Panels;
<<<<<<< Updated upstream
using UnityEngine;
using UnityEngine.UI;
=======
using GridBuildSystem.BuildSystem;
using GridBuildSystem.LoadSystem;
using GridBuildSystem.SaveSystem;
using UnityEngine;
>>>>>>> Stashed changes

namespace GridBuildSystem.Testing
{
    public class SceneTest : MonoBehaviour
    {
        public BuildPanel BuildPanel;
        public BuildPanelSettings buildPanelSettings;
<<<<<<< Updated upstream
        
        public GridSettings gridSettings;
        public Button testButton;
        private GridTestDrawer _gridTestDrawer;
        
        public Canvas _canvas;

        private void Awake()
        {
            var panel = Instantiate(buildPanel, _canvas.transform);
            panel.Construct(buildPanelSettings);
=======

        public TextPanel TextPanel;
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
        
        public XOREncryptorSettings EncryptorSettings;

        private Camera _camera;
        public Canvas canvas;

        private ISaveSystem _saveSystem;
        private ILoadSystem _loadSystem;


        private void Awake()
        {
            var buildPanel = Instantiate(BuildPanel, canvas.transform);
            buildPanel.Construct(buildPanelSettings, testBuildings);

            var textPanel = Instantiate(TextPanel, canvas.transform);
            textPanel.Construct(textPanelSettings);
            textPanel.Hide();

            _camera = Camera.main;

            _grid = gridSettings.GetGrid<IBuilding>();

            var gridTexture = Instantiate(gridDrawerSettings.TexturePrefab, gridSettings.GridOrigin,
                Quaternion.identity);
            gridTexture.transform.SetParent(Environment);
            gridTexture.SetActive(false);

            var gridDrawer = new GridDrawer(gridDrawerSettings, gridTexture);
            _gridDrawer = gridDrawer;
>>>>>>> Stashed changes

            panel.OnBuildingChoose += s => Debug.Log(s);
            panel.OnPlacementModeActive += () => Debug.Log("Placement Mode");
            panel.OnDestroyModeActive += () => Debug.Log("Destroy Mode");

<<<<<<< Updated upstream
            var grid = gridSettings.GetGrid<Cell>();
            _gridTestDrawer = new GridTestDrawer(grid, Color.white);
            
            testButton.onClick.AddListener(() => _gridTestDrawer.Draw());
        }

        public class Cell : IGridCell{}
=======
            var buildingsHolder = new BuildingsSaveDataHolder();

            var buildingsSpawner = new DefaultBuildingsSpawner(buildings, buildingsHolder, Environment);
            buildPanel.OnBuildingChoose += buildingsSpawner.SetValue;

            _placementMode = new PlacementMode(_grid, _camera, inputReader, buildingsSpawner);
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

            var encryptor = new XOREncryptor(EncryptorSettings);
            
            var serializer = new JSONSerializer(encryptor);

            _saveSystem = new BuildingsSaveSystem(buildingsHolder, serializer);

            var loader = new JSONBuildingsLoader(encryptor);
            _loadSystem = new BuildingsLoadSystem(loader, buildingsSpawner, buildingsSpawner, _grid);
        }

        private void Start()
        {
            try
            {
                _loadSystem.Load();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            inputReader.EnableActionMap();
        }

        private void OnDestroy() => _saveSystem.Save();
>>>>>>> Stashed changes
    }
}