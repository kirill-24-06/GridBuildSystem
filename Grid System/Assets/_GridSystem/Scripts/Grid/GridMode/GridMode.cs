using UnityEngine;

namespace GridBuildSystem.Grid
{
    public abstract class GridMode<T>: IGridMode where T : IGridCell
    {
        protected Grid<T> _grid;
        
        public int Width => _grid.Width;
        public int Height => _grid.Height;
        
        public abstract Vector3 GetWorldPosition(int x, int y, bool withOffset = false);
        public abstract T GetElement(Vector3 worldPosition);
        public abstract void SetElement(Vector3 worldPosition, T element);
        public abstract void SetElement(int x, int y, T element);
        public abstract bool CheckSetPossibility(Vector3 worldPosition, T element);
        public abstract void RemoveElement(T element);
        
        protected abstract Vector2Int ConvertWorldToGrid(Vector3 worldPosition);
        protected abstract T GetElement(int x, int y);
        protected abstract bool CheckSetPossibility(int x, int y, T element);

        public Vector3 GetWorldRelativePosition(Vector3 currentWorldPosition, bool withOffset = false)
        {
            var gridPosition = ConvertWorldToGrid(currentWorldPosition);
            return GetWorldPosition(gridPosition.x, gridPosition.y, withOffset);
        }
    }
}