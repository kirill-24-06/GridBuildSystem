using GridBuildSystem.BuildSystem.Buildings;
using UnityEngine;

namespace GridBuildSystem.SaveSystem
{
    public class BuildingsSaveSystem : ISaveSystem
    {
        private readonly IBuildingsSaveDataProvider _buildingsSaveData;
        
        private readonly ISerializer _serializer;

        public BuildingsSaveSystem(IBuildingsSaveDataProvider buildingsSaveData, ISerializer serializer)
        {
            _buildingsSaveData = buildingsSaveData;
            _serializer = serializer;
        }
        
        public void Save()
        {
            var savedBuildings = GetSavedBuildings();

            if (savedBuildings.Buildings.Length == 0) return;
           
            _serializer.Serialize(savedBuildings);
        }

        private SavedBuildings GetSavedBuildings()
        {
            var buildings = _buildingsSaveData.GetBuildingsSaveData();
            var buildingsData = new BuildingSaveData[buildings.Count];

            for (var i = 0; i < buildings.Count; i++)
            {
                var saveData = new BuildingSaveData
                {
                    Name = buildings[i].Name,
                    Position = new Position
                    {
                        X = buildings[i].GridPosition.x,
                        Y = buildings[i].GridPosition.y
                    }
                };
                
                buildingsData[i] = saveData;
            }

            var savedBuildings = new SavedBuildings
            {
                Buildings = buildingsData
            };
            
            return savedBuildings;
        }
    }
}