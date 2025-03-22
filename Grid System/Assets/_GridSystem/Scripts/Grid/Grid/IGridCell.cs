using UnityEngine;

namespace GridBuildSystem.Grid
{
    public interface IGridCell
    {
        Vector3Int Position { get; }
        Vector3Int Size { get; }
        void SetPosition(Vector3Int position);
    }
}