using System.Collections.Generic;
using GridBuildSystem.BuildSystem;
using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.LoadSystem;
using GridBuildSystem.SaveSystem;
using UnityEngine;

namespace GridBuildSystem
{
    public class LoadSystemInstaller : IInstaller
    {
        private readonly GridBuildSystemSettings _settings;
        private readonly ICreator _creator;
        private readonly IValueReceiver<string> _valueReceiver;
        private readonly GridInstaller _gridInstaller;
        private readonly IDecryptor _decryptor;

        public LoadSystemInstaller(GridBuildSystemSettings settings,
            IDecryptor decryptor, ICreator creator, IValueReceiver<string> valueReceiver, GridInstaller gridInstaller)
        {
            _settings = settings;
            _decryptor = decryptor;
            _creator = creator;
            _valueReceiver = valueReceiver;
            _gridInstaller = gridInstaller;
        }

        public void Install()
        {
            var grid = _gridInstaller.Grid;
            var deserializer = _settings.GetDeserializer(_decryptor);

            var loadSystem = new BuildingsLoadSystem(deserializer, _creator, _valueReceiver, grid);

            var trigger = Object.Instantiate(_settings.LoadSystemGO);
            trigger.Construct(loadSystem);
        }
    }
}