using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IBuildingSettings : IPlaceableData,IBuildingUIData
    {
        Vector3Int Size { get; }
        Transform Prefab { get; }
        IBuilding CreateBuilding();
    }
}