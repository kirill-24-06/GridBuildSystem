using UnityEngine;

namespace GridBuildSystem.Grid
{
    public interface IDrawer
    {
        void Draw();
    }

    public class GridTestDrawer : IDrawer
    {
        private readonly IGridMode _grid;
        private readonly Color _gridColor;
        
        public GridTestDrawer(IGridMode grid, Color color)
        {
            _grid = grid;
            _gridColor = color;
        }
        
        public void Draw()
        {
            Gizmos.color = _gridColor;
            
            for (var i = 0; i < _grid.Width; i++)
            {
                for (var j = 0; j < _grid.Height; j++)
                {
                    Debug.DrawLine(_grid.GetWorldPosition(i, j), _grid.GetWorldPosition(i, j + 1), _gridColor, 100f);
                    Debug.DrawLine(_grid.GetWorldPosition(i, j), _grid.GetWorldPosition(i + 1, j), _gridColor, 100f);
                   
                }
            }
        
            Debug.DrawLine(_grid.GetWorldPosition(0, _grid.Height), _grid.GetWorldPosition(_grid.Width, _grid.Height),
                _gridColor, 100f);
            Debug.DrawLine(_grid.GetWorldPosition(_grid.Width, 0), _grid.GetWorldPosition(_grid.Width, _grid.Height),
                _gridColor, 100f);
        }
    }
}