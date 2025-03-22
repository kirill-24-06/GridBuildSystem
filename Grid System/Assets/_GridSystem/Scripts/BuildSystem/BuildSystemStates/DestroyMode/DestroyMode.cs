using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using UnityEngine;

namespace GridBuildSystem.BuildSystem
{
    public class DestroyMode : BuildSystemMode
    {
        private readonly IReleaser _buildingsReleaser;

        public DestroyMode(GridMode<IBuilding> grid, Camera camera, IInputReader input, IReleaser releaser)
        {
            _grid = grid;
            _camera = camera;
            _input = input;
            _buildingsReleaser = releaser;
        }

        public override void Enter()
        {
            _input.OnLeftMouseClick += DestroyBuilding;
            _input.OnRightMouseClick += Exit;
            
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
            var worldPoint = _camera.ScreenToWorldPoint(_input.MousePosition);

            var building = _grid.GetElement(worldPoint);

            if (building == null) return;

            _grid.RemoveElement(building);

            _buildingsReleaser.Release(building);
        }
    }
}