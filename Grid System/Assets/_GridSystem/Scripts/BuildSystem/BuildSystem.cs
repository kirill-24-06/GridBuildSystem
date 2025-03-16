using System;
using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using UnityEngine;

namespace GridBuildSystem.BuildSystem
{
    public class BuildSystem
    {
    }

    public interface IState
    {
        void Enter();
        void Exit();
    }

    public abstract class BuildSystemState : IState
    {
        public event Action OnEnter = delegate { };
        public event Action OnExit = delegate { };

        public virtual void Enter()
        {
            OnEnter.Invoke();
        }

        public virtual void Exit()
        {
            OnExit.Invoke();
        }
    }

    public class PlacementModeTest : BuildSystemState
    {
        private readonly GridMode<IBuilding> _grid;
        private readonly Camera _camera;
        private readonly InputReader _input;
        private readonly BuildingSettings _building;
        private IBuilding _activeBuilding;

        public PlacementModeTest(GridMode<IBuilding> grid, Camera camera, InputReader input, BuildingSettings building)
        {
            _grid = grid;
            _camera = camera;
            _input = input;
            _building = building;
        }

        public override void Enter()
        {
            _activeBuilding = _building.CreateBuilding();

            _input.OnMousePositionChanged += MoveBuilding;
            _input.OnLeftMouseClick += PlaceBuilding;
            _input.OnRightMouseClick += Exit; //TODO

            base.Enter();
        }

        public override void Exit()
        {
            _input.OnMousePositionChanged -= MoveBuilding;
            _input.OnLeftMouseClick -= PlaceBuilding;
            _input.OnRightMouseClick -= Exit;

            if (_activeBuilding != null)
            {
                GameObject.Destroy(_activeBuilding.Prefab.gameObject);
                _activeBuilding = null;
            }
            
            base.Exit();
        }

        private void PlaceBuilding()
        {
            var pos = _camera.ScreenToWorldPoint(_input.MousePosition);

            var prefabPosition = _grid.GetWorldRelativePosition(pos, true);

            var canBePlaced = _grid.CheckSetAvailability(pos, _activeBuilding);

            if (!canBePlaced) return;
            
            _grid.SetElement(pos, _activeBuilding);
            
            _activeBuilding.Prefab.position = prefabPosition;
            _activeBuilding.OnPlaced();
            _activeBuilding = null;
            
            Exit();
        }

        private void MoveBuilding(Vector2 position)
        {
            var pos = _camera.ScreenToWorldPoint(position);

            var newPos = _grid.GetWorldRelativePosition(pos, true);

            _activeBuilding.Prefab.position = newPos;

            var canBePlaced = _grid.CheckSetAvailability(pos, _activeBuilding);
            _activeBuilding.ChangeColor(canBePlaced);
        }
    }

    public class DestroyModeTest : BuildSystemState
    {
        private readonly GridMode<IBuilding> _grid;
        private readonly Camera _camera;
        private readonly InputReader _input;

        public DestroyModeTest(GridMode<IBuilding> grid, Camera camera, InputReader input)
        {
            _grid = grid;
            _camera = camera;
            _input = input;
        }

        public override void Enter()
        {
            _input.OnLeftMouseClick += DestroyBuilding;
            _input.OnRightMouseClick += Exit; //TODO
            base.Enter();
        }

        public override void Exit()
        {
            _input.OnLeftMouseClick -= DestroyBuilding;
            _input.OnRightMouseClick -= Exit;
            base.Exit();
        }

        private void DestroyBuilding()
        {
            var pos = _camera.ScreenToWorldPoint(_input.MousePosition);

            var building = _grid.GetElement(pos);

            if (building == null) return;
            
            _grid.RemoveElement(building);
            
            GameObject.Destroy(building.Prefab.gameObject);//ToDO
        }
    }
}