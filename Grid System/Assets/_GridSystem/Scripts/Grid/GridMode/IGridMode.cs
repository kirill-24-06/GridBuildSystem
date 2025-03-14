using UnityEngine;

namespace GridBuildSystem.Grid
{
    public interface IGridMode
    {
        int Width { get; }
        int Height { get; }
        Vector3 GetWorldPosition(int x, int y);
    }
}