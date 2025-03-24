using System;

namespace GridBuildSystem.UI.Panels
{
    public interface IBuildPanel : IPanel
    {
        public event Action<string> OnBuildingChoose;
        public event Action OnPlacementModeActive;
        public event Action OnDestroyModeActive;
    }
}