using UnityEngine;

namespace GridBuildSystem.Grid
{
    public class Grid2D<T> : GridMode<T> where T : IGridCell
    {
        public Grid2D(Grid<T> grid)
        {
            _grid = grid;
        }

        public override Vector3 GetWorldPosition(int x, int y, bool withOffset = false)
        {
            if (!withOffset)
            {
                return new Vector3(x, y) * _grid.CellSize + _grid.Origin;
            }

            var offset = new Vector3(_grid.CellSize, _grid.CellSize) * 0.5f;
            return new Vector3(x, y) * _grid.CellSize + _grid.Origin + offset;
        }

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

        public override bool CheckSetAvailability(Vector3 worldPosition, T element)
        {
            var gridPosition = ConvertWorldToGrid(worldPosition);
            return CheckSetAvailability(gridPosition.x, gridPosition.y, element);
        }

        public override void RemoveElement(T element)
        {
            for (var i = 0; i < element.Size.x; i++)
            {
                for (var j = 0; j < element.Size.y; j++)
                {
                    _grid.SetValue(element.Position.x + i, element.Position.y + j, default);
                }
            }
        }

        protected override Vector2Int ConvertWorldToGrid(Vector3 worldPosition)
        {
            var x = Mathf.FloorToInt((worldPosition - _grid.Origin).x / _grid.CellSize);
            var y = Mathf.FloorToInt((worldPosition - _grid.Origin).y / _grid.CellSize);

            return new Vector2Int(x, y);
        }

        protected override void SetElement(int x, int y, T element)
        {
            if (x < 0 || y < 0 || x > _grid.Width - element.Size.x || y > _grid.Height - element.Size.y) return;

            element.SetPosition(new Vector3Int(x, y));

            for (var i = 0; i < element.Size.x; i++)
            {
                for (var j = 0; j < element.Size.y; j++)
                {
                    _grid.SetValue(x + i, y + j, element);
                }
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

        protected override bool CheckSetAvailability(int x, int y, T element)
        {
            if (x < 0 || y < 0 || x > _grid.Width - element.Size.x || y > _grid.Height - element.Size.y) return false;

            for (var i = 0; i < element.Size.x; i++)
            {
                for (var j = 0; j < element.Size.y; j++)
                {
                    if (_grid.GetValue(x + i, y + j) != null) return false;
                }
            }

            return true;
        }
    }
}