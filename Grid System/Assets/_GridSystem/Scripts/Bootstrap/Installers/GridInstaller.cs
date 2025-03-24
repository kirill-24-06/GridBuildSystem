using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using UnityEngine;

namespace GridBuildSystem
{
    public class GridInstaller : IInstaller
    {
        private readonly IGridSettings _gridSettings;
        private readonly IGridDrawerSettings _gridDrawerSettings;

        private readonly Transform _parentTransform;

        public GridMode<IBuilding> Grid { get; private set; }
        public IGameObjectDrawer GridDrawer { get; private set; }

        public GridInstaller(IGridSettings gridSettings, IGridDrawerSettings gridDrawerSettings,
            Transform parentTransform)
        {
            _gridSettings = gridSettings;
            _gridDrawerSettings = gridDrawerSettings;
            _parentTransform = parentTransform;
        }

        public void Install()
        {
            Grid = _gridSettings.GetGrid<IBuilding>();

            var gridTexture = Object.Instantiate(_gridDrawerSettings.TexturePrefab, _gridSettings.GridOrigin,
                Quaternion.identity);
            gridTexture.transform.SetParent(_parentTransform);
            gridTexture.SetActive(false);

            var gridDrawer = new GridDrawer(_gridDrawerSettings, gridTexture);
            GridDrawer = gridDrawer;
        }
    }
}