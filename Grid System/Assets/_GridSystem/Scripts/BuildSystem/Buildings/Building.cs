using UnityEngine;
using GridBuildSystem.Grid;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IBuildingSaveData // To save system
    {
        Vector2Int Position { get; }
        string Name { get; }
    }

    public interface IPlaceableData
    {
        Color AvailableColor { get; }
        Color UnavailableColor { get; }
        Color DefaultColor { get; }
    }

    public interface IPlaceable
    {
        void ChangeColor(bool canBePlaced);
        void OnPlaced();
    }

    public interface IBuildingSettings : IPlaceableData
    {
        Vector3Int Size { get; }
        Transform Prefab { get; }
        IBuilding CreateBuilding();
    }

    public interface IBuilding : IPlaceable, IGridCell
    {
        Transform Prefab { get; }
    }

    public class Building : IBuilding
    {
        private readonly BuildingSettings _settings;
        private readonly Renderer _renderer;
        public Transform Prefab { get; private set; }
        public Vector3Int Size => _settings.Size;

        public Vector3Int Position { get; private set; }

        public Building(BuildingSettings settings)
        {
            _settings = settings;
            
            var go = GameObject.Instantiate(_settings.Prefab.gameObject);
            Prefab = go.transform;

            _renderer = Prefab.GetComponentInChildren<Renderer>();

            Prefab.name = _settings.Prefab.name;
        }

        public void SetPosition(Vector3Int position) => Position = position;

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