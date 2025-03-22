using UnityEngine;

namespace GridBuildSystem.Grid
{
    [CreateAssetMenu(fileName = "GridVisualSettings", menuName = "ScriptableObjects/Grid/GridVisualSettings",
        order = 1)]
    public class GridDrawerSettings : ScriptableObject, IGridDrawerSettings
    {
        [field: SerializeField] public GridSettings GridSettings { get; private set; }
        [field: SerializeField] public GameObject TexturePrefab { get; private set; }
        [field: SerializeField] public Color GridColor { get; private set; }

        [field: SerializeField, Range(0.01f, 0.05f)]
        public float GridLinesThickness { get; private set; } = 0.05f;
    }
}