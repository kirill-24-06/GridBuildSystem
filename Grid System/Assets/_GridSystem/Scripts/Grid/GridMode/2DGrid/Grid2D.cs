using UnityEngine;

namespace GridBuildSystem.Grid
{
    public class Grid2D<T> : GridMode<T> where T : IGridCell
    {
        public Grid2D(Grid<T> grid)
        {
            _grid = grid;
        }

        public override Vector3 GetWorldPosition(int x, int y) => new Vector3(x, y) * _grid.CellSize + _grid.Origin;

        public override T GetElement(Vector3 worldPosition)
        {
            var gridPosition = ConvertWorldToGrid(worldPosition);
            return GetElement(gridPosition.x, gridPosition.y);
        }

        public override void SetElement(Vector3 worldPosition, T element)
        {
            var gridPosition = ConvertWorldToGrid(worldPosition);
            SetElement(gridPosition.x, gridPosition.y, element);
        }

        protected override Vector2Int ConvertWorldToGrid(Vector3 worldPosition)
        {
            var x = Mathf.FloorToInt((worldPosition - _grid.Origin).x / _grid.CellSize);
            var y = Mathf.FloorToInt((worldPosition - _grid.Origin).y / _grid.CellSize);

            return new Vector2Int(x, y);
        }

        protected override void SetElement(int x, int y, T element)
        {
            if (x >= 0 && y >= 0 && x < _grid.Width && y < _grid.Height)
            {
                _grid.SetValue(x, y, element);
            }
        }

        protected override T GetElement(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _grid.Width && y < _grid.Height)
            {
                return _grid.GetValue(x, y);
            }

            return default;
        }
    }
}