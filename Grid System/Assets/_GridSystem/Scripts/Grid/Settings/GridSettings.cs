using UnityEngine;

namespace GridBuildSystem.Grid
{
    [CreateAssetMenu(fileName = "GridSettings", menuName = "ScriptableObjects/Grid", order = 0)]
    public class GridSettings : ScriptableObject, IGridSettings
    {
        [field: SerializeField] public GridMode GridMode { get; private set; }

        [field: SerializeField] public int Width { get; private set; }
        [field: SerializeField] public int Height { get; private set; }
        [field: SerializeField] public float CellSize { get; private set; }
        [field: SerializeField] public Vector3 GridOrigin { get; private set; }

        public GridMode<T> GetGrid<T>() where T : IGridCell
        {
            return GridMode switch
            {
                GridMode.Grid2D => CreateGrid2D<T>(),
                GridMode.None => CreateGrid2D<T>(),
                _ => CreateGrid2D<T>()
            };
        }

        private Grid2D<T> CreateGrid2D<T>() where T : IGridCell
        {
            var grid = new Grid<T>(Width, Height, CellSize, GridOrigin);

            return new Grid2D<T>(grid);
        }
    }
}