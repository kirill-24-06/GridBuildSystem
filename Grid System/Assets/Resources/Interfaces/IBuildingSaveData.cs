using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IBuildingSaveData
    {
        Vector2Int GridPosition { get; }
        string Name { get; }
    }
}