using System.Collections.Generic;
using System.Linq;
using GridBuildSystem.BuildSystem.Buildings;
using UnityEngine;

namespace GridBuildSystem.BuildSystem
{
    public class DefaultBuildingsSpawner: ISpawner
    {
        private readonly Dictionary<string, IBuildingSettings> _buildings;

        private readonly Transform _buildingsHolder;
        
        private string _currentBuilding;

        public DefaultBuildingsSpawner(Dictionary<string, IBuildingSettings> buildings, Transform buildingsParent)
        {
            _buildings = buildings;
            
            _buildingsHolder = new GameObject("Buildings").transform;
            
            _buildingsHolder.SetParent(buildingsParent);
            
            _currentBuilding = _buildings.Keys.First();
        }

        public void OnBuildingChoose(string buildingName) => _currentBuilding = buildingName;
        
        public IBuilding Create()
        {
            var building = _buildings[_currentBuilding].CreateBuilding();
            building.Prefab.transform.SetParent(_buildingsHolder);
            
            return building;
        }

        public void Release(IBuilding building) => Object.Destroy(building.Prefab.gameObject);
      
    }
}