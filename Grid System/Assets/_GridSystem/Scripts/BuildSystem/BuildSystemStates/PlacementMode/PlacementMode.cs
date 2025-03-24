using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using UnityEngine;

namespace GridBuildSystem.BuildSystem
{
    public class PlacementMode : BuildSystemMode
    {
        private readonly ISpawner _buildingsSpawner;
        private IBuilding _activeBuilding;

        public PlacementMode(GridMode<IBuilding> grid, ISpawner buildingsSpawner, IInputReader input, Camera camera)
        {
            _grid = grid;
            _camera = camera;
            _input = input;
            _buildingsSpawner = buildingsSpawner;
        }

        public override void Enter()
        {
            _activeBuilding = _buildingsSpawner.Create();

            _input.OnMousePositionChanged += MoveBuilding;
            _input.OnLeftMouseClick += PlaceBuilding;
            _input.OnRightMouseClick += Exit;

            base.Enter();
        }

        public override void Exit()
        {
            _input.OnMousePositionChanged -= MoveBuilding;
            _input.OnLeftMouseClick -= PlaceBuilding;
            _input.OnRightMouseClick -= Exit;

            if (_activeBuilding != null)
            {
                _buildingsSpawner.Release(_activeBuilding);
                _activeBuilding = null;
            }

            base.Exit();
        }

        private void PlaceBuilding()
        {
            var worldPoint = _camera.ScreenToWorldPoint(_input.MousePosition);

            var prefabPosition = _grid.GetWorldRelativePosition(worldPoint, true);

            var canBePlaced = _grid.CheckSetPossibility(worldPoint, _activeBuilding);

            if (!canBePlaced) return;

            _grid.SetElement(worldPoint, _activeBuilding);

            _activeBuilding.Prefab.position = prefabPosition;
            _activeBuilding.OnPlaced();
            _activeBuilding = null;

            Exit();
        }

        private void MoveBuilding(Vector2 position)
        {
            var worldPoint = _camera.ScreenToWorldPoint(position);

            var worldRelativeToGridPosition = _grid.GetWorldRelativePosition(worldPoint, true);

            _activeBuilding.Prefab.position = worldRelativeToGridPosition;

            var canBePlaced = _grid.CheckSetPossibility(worldPoint, _activeBuilding);
            _activeBuilding.ChangeColor(canBePlaced);
        }
    }
}