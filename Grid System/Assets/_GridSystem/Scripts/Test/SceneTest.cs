using GridBuildSystem.Input;
using UnityEngine;

namespace GridBuildSystem.Testing
{
    public class SceneTest : MonoBehaviour
    {
        public Vector3 gridOrigin;
        public GameObject testPrefab;
        public GameObject testPrefab2;
        private Grid.Grid _grid;
        public InputReader inputReader;

        private void Awake()
        {
            _grid = new Grid.Grid(10,10,2f,gridOrigin, testPrefab);
            
            inputReader.OnLeftMouseClick += OnClick;
            inputReader.OnRightMouseClick += OnClick2;
        }

        private void Start()
        {
            inputReader.EnableActionMap();
        }

        public void OnClick()
        {
            var camera = Camera.main;

            var worldPosition = camera.ScreenToWorldPoint(inputReader.MousePosition);
            Debug.Log(worldPosition);
            
            _grid.Test(worldPosition, testPrefab2);
        }

        public void OnClick2() => Debug.Log("OnRightClick2");
    }
}
