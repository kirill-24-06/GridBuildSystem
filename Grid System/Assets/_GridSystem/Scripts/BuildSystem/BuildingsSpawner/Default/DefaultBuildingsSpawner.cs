using System.Collections.Generic;
using System.Linq;
using GridBuildSystem.BuildSystem.Buildings;
using UnityEngine;

namespace GridBuildSystem.BuildSystem
{
    public class DefaultBuildingsSpawner: ISpawner, IValueReceiver<string>
    {
        private readonly Dictionary<string, IBuildingSettings> _buildings;
        
        private readonly IBuildingsRegister _buildingsRegister;

        private readonly Transform _buildingsHolder;
        
        private string _currentBuilding;

        public DefaultBuildingsSpawner(Dictionary<string, IBuildingSettings> buildings, IBuildingsRegister buildingsRegister ,Transform buildingsParent)
        {
            _buildings = buildings;
            
            _buildingsRegister = buildingsRegister;
            
            _buildingsHolder = new GameObject("Buildings").transform;
            _buildingsHolder.SetParent(buildingsParent);
            
            _currentBuilding = _buildings.Keys.First();
        }

        public void SetValue(string value) => _currentBuilding = value;
        
        public IBuilding Create()
        {
            var building = _buildings[_currentBuilding].CreateBuilding();
            building.Prefab.transform.SetParent(_buildingsHolder);
            
            _buildingsRegister.Register(building);
            
            return building;
        }

        public void Release(IBuilding building)
        {
            _buildingsRegister.Unregister(building);
            Object.Destroy(building.Prefab.gameObject);
        }
    }
}