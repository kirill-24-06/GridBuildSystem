using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.SaveSystem;
using UnityEngine;

namespace GridBuildSystem
{
    public class SaveSystemInstaller : IInstaller
    {
        private readonly GridBuildSystemSettings _settings;
        private readonly IBuildingsSaveDataHolder _buildingsSaveDataHolder;
        private readonly IEncryptor _encryptor;

        public SaveSystemInstaller(GridBuildSystemSettings gridBuildSystemSettings,
            IBuildingsSaveDataHolder buildingsSaveDataHolder, IEncryptor encryptor)
        {
            _settings = gridBuildSystemSettings;
            _buildingsSaveDataHolder = buildingsSaveDataHolder;
            _encryptor = encryptor;
        }

        public void Install()
        {
            var serializer = _settings.GetSerializer(_encryptor);
            var saveSystem = new BuildingsSaveSystem(_buildingsSaveDataHolder, serializer);

            var trigger = Object.Instantiate(_settings.SaveSystemGO);
            trigger.Construct(saveSystem);
        }
    }
}