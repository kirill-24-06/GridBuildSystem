using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IBuildingUIData
    {
        Sprite BuildingImage { get;}
        string BuildingName { get; }
    }
}