using UnityEngine;

namespace GridBuildSystem.Grid
{
    public class Grid
    {
        private int _width;
        private int _height;
        private float _cellSize;
        
        private Vector3 _gridOrigin;
        
        private IGridElement[,] _gridElements;

        private GameObject _test;

        public Grid(int width, int height, float cellSize, Vector3 gridOrigin, GameObject testPrefab)
        {
            _width = width;
            _height = height;
            _cellSize = cellSize;
            _gridOrigin = gridOrigin;
            
            _gridElements = new IGridElement[_width, _height];
            
            _test = testPrefab;

            for (var i = 0; i < _gridElements.GetLength(0); i++)
            { 
                for (var j = 0; j < _gridElements.GetLength(1); j++)
                {
                    Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100f);
                }
            }
            
            Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(_width, _height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(_width, 0), GetWorldPosition(_width , _height), Color.white, 100f);
        }

        private Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x,y) * _cellSize + _gridOrigin;
        }

        private Vector2Int ConvertWorldPosition(Vector3 worldPosition)
        {
            var x= Mathf.FloorToInt((worldPosition - _gridOrigin).x / _cellSize);
            var y = Mathf.FloorToInt((worldPosition - _gridOrigin).y / _cellSize);
            
            return new Vector2Int(x, y);
        }
        
        public void SetElement(int x, int y,IGridElement element)
        {
            if (x>= 0 && y >= 0 && x < _width && y < _height)
            {
                _gridElements[x, y] = element;
            }
        }

        public void SetElement(Vector3 worldPosition, IGridElement element)
        {
            var gridPosition = ConvertWorldPosition(worldPosition);
            
            SetElement(gridPosition.x, gridPosition.y, element);
        }

        public void Test(Vector3 worldPosition, GameObject element)
        {
            var gridPosition = ConvertWorldPosition(worldPosition);
            if (gridPosition.x >= 0 && gridPosition.y >= 0 && gridPosition.x < _width && gridPosition.y < _height)
            {
                var go = GameObject.Instantiate(element);
                go.transform.localPosition = GetWorldPosition(gridPosition.x, gridPosition.y) +
                                             new Vector3(_cellSize, _cellSize) * 0.5f;
                
            }
            
            
        }
        public IGridElement GetElement(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
            {
                return _gridElements[x, y];
            }
            
            return null;
        }

        public IGridElement GetElement(Vector3 worldPosition)
        {
            var gridPosition = ConvertWorldPosition(worldPosition);
            
            return GetElement(gridPosition.x, gridPosition.y);
        }
    }

    public interface IGridElement
    {
        
    }
}
