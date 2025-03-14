using UnityEngine;

namespace GridBuildSystem.Grid
{
    public interface IGridCell
    {
    }

    public class Grid<T> where T : IGridCell
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public float CellSize { get; private set; }
        public Vector3 Origin { get; private set; }

        private readonly T[,] _cells;

        public Grid(int width, int height, float cellSize, Vector3 origin)
        {
            Width = width;
            Height = height;

            CellSize = cellSize;
            Origin = origin;

            _cells = new T[Width, Height];
        }

        public void SetValue(int x, int y, T value) => _cells[x, y] = value;
        public T GetValue(int x, int y) => _cells[x, y];
    }
}