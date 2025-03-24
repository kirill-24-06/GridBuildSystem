using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public class Building : IBuilding
    {
        private readonly IBuildingSettings _settings;
        private Renderer _renderer;
        public Transform Prefab { get; private set; }
        public Vector3Int Size => _settings.Size;
        public string Name => _settings.BuildingName;
        public Vector2Int Position { get; private set; }
        public Vector2Int GridPosition => Position;

        public Building(IBuildingSettings settings)
        {
            _settings = settings;
        }

        public void Initialize(Transform prefab, Renderer renderer)
        {
            Prefab = prefab;
            _renderer = renderer;
        }

        public void SetPosition(Vector2Int position) => Position = position;

        public void ChangeColor(bool canBePlaced)
        {
            _renderer.material.color = canBePlaced ? _settings.AvailableColor : _settings.UnavailableColor;
        }

        public void OnPlaced()
        {
            _renderer.material.color = _settings.DefaultColor;
            _renderer.sortingOrder = -1;
        }
    }
}