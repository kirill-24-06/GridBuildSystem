using System.Collections.Generic;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public class BuildingsSaveDataHolder : IBuildingsSaveDataHolder
    {
        private readonly List<IBuildingSaveData> _buildings = new();

        public void Register(IBuilding building) => _buildings.Add(building);
        public void Unregister(IBuilding building) => _buildings.Remove(building);
        public List<IBuildingSaveData> GetBuildingsSaveData() => _buildings;
    }
}