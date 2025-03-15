using UnityEngine;

namespace GridBuildSystem.Grid
{
    public enum GridMode
    {
        None = 0,
        Grid2D = 1,
    }
    
    public interface IGridSettings
    {
        int Width { get; }
        int Height { get; }
        float CellSize { get; }
        Vector3 GridOrigin { get; }
        GridMode GridMode { get; }
        GridMode<T> GetGrid<T>() where T : IGridCell;
    }
}