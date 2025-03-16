using UnityEngine;

namespace GridBuildSystem.Grid
{
    public interface IGridMode
    {
        int Width { get; }
        int Height { get; }
        Vector3 GetWorldPosition(int x, int y, bool withOffset = false);
        Vector3 GetWorldRelativePosition(Vector3 currentWorldPosition, bool withOffset = false);
    }
}