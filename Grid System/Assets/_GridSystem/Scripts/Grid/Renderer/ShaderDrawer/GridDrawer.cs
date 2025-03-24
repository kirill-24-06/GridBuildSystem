using UnityEngine;

namespace GridBuildSystem.Grid
{
    public class GridDrawer : IGameObjectDrawer
    {
        private static readonly int Scale = Shader.PropertyToID("_Scale");
        private static readonly int Thickness = Shader.PropertyToID("_Thickness");
        private static readonly int Color = Shader.PropertyToID("_Color");

        private readonly GameObject _gridTexture;

        private const float _positionModifier = 2.0f;

        public GridDrawer(IGridDrawerSettings gridDrawerSettings, GameObject gridTexture)
        {
            _gridTexture = gridTexture;

            var material = gridTexture.GetComponentInChildren<Renderer>().material;

            var gridScale = new Vector2(gridDrawerSettings.GridSettings.Width,
                gridDrawerSettings.GridSettings.Height);

            material.SetVector(Scale, gridScale);
            material.SetColor(Color, gridDrawerSettings.GridColor);
            material.SetFloat(Thickness, gridDrawerSettings.GridLinesThickness);

            var texture = _gridTexture.transform.Find("Texture").gameObject;

            var textureScale = gridScale * gridDrawerSettings.GridSettings.CellSize;
            var texturePosition = textureScale / _positionModifier;

            texture.transform.localScale = textureScale;
            texture.transform.localPosition = texturePosition;
        }

        public void Draw() => _gridTexture.SetActive(true);
        public void Hide() => _gridTexture.SetActive(false);
    }

    public interface IGridDrawerSettings
    {
        GridSettings GridSettings { get; }
        GameObject TexturePrefab { get; }
        Color GridColor { get; }
        float GridLinesThickness { get; }
    }
}