using UnityEngine;
using GridBuildSystem.BuildSystem.Buildings;

namespace GridBuildSystem.UI.Panels
{
    [CreateAssetMenu(fileName = "BuildPanelSettings", menuName = "ScriptableObjects/UI/Panels/BuildPanel", order = 0)]
    public class BuildPanelSettings : ScriptableObject, IBuildPanelSettings
    {
        [SerializeField] private TextSettings textSettings1;
        [SerializeField] private TextSettings textSettings2;

        public IText PlacementModeText => textSettings1;
        public IText DestroyModeText => textSettings2;
    }
}