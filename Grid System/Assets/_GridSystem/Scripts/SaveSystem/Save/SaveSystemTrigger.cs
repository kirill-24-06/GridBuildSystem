using GridBuildSystem.SaveSystem;
using UnityEngine;

namespace GridBuildSystem
{
    public class SaveSystemTrigger : MonoBehaviour
    {
        private ISaveSystem _saveSystem;

        public void Construct(ISaveSystem saveSystem) => _saveSystem = saveSystem;

        private void OnApplicationQuit() => _saveSystem?.Save();
    }
}