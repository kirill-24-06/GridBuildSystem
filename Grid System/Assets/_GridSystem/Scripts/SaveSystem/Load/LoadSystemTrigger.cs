using GridBuildSystem.LoadSystem;
using UnityEngine;

namespace GridBuildSystem
{
    public class LoadSystemTrigger : MonoBehaviour
    {
        private ILoadSystem _loadSystem;

        public void Construct(ILoadSystem loadSystem) => _loadSystem = loadSystem;

        private void Start()
        {
            _loadSystem.Load();
            Destroy(gameObject);
        }
    }
}