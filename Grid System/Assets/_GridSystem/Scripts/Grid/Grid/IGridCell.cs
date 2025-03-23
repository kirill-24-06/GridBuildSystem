using UnityEngine;

namespace GridBuildSystem.Grid
{
    public interface IGridCell
    {
        Vector2Int Position { get; }
        Vector3Int Size { get; }
        void SetPosition(Vector2Int position);
    }
}