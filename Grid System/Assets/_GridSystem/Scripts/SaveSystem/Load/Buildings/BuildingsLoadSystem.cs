using GridBuildSystem.BuildSystem;
using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;

namespace GridBuildSystem.LoadSystem
{
    public class BuildingsLoadSystem : ILoadSystem
    {
        private readonly GridMode<IBuilding> _grid;

        private readonly ICreator _buildingCreator;
        private readonly IValueReceiver<string> _valueReceiver;

        private readonly IBuildingsLoader _buildingLoader;

        public BuildingsLoadSystem(IBuildingsLoader buildingLoader, ICreator buildingCreator,
            IValueReceiver<string> valueReceiver, GridMode<IBuilding> grid)
        {
           _grid = grid;
           _buildingCreator = buildingCreator;
           _valueReceiver = valueReceiver;
           _buildingLoader = buildingLoader;
        }

        public void Load()
        {
            if (!_buildingLoader.LoadBuildings(out var savedBuildings)) return;

            foreach (var buildingData in savedBuildings.Buildings)
            {
                _valueReceiver.SetValue(buildingData.Name);

                var building = _buildingCreator.Create();

                var prefabPosition = _grid.GetWorldPosition(buildingData.Position.X, buildingData.Position.Y, true);

                _grid.SetElement(buildingData.Position.X, buildingData.Position.Y, building);
                building.Prefab.position = prefabPosition;
                building.OnPlaced();
            }
        }
    }
}