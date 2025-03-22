using GridBuildSystem.Grid;
using GridBuildSystem.SaveSystem;
using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IBuilding : IPlaceable,IGridCell
    {
        Transform Prefab { get; }
    }
}