using UnityEngine.UI;
using GridBuildSystem.UI;

namespace GridBuildSystem.UI.Panels
{
    public interface IBuildPanelSettings
    {
        IBuildingUIData Building1Data { get; }
        
        IBuildingUIData Building2Data { get; }
        
        IBuildingUIData Building3Data { get; }
        
        IText PlacementModeText { get; }
        IText DestroyModeText { get; }
    }
}