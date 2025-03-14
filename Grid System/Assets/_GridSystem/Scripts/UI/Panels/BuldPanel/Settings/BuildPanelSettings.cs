using UnityEngine;

namespace GridBuildSystem.UI.Panels
{
    [CreateAssetMenu(fileName = "BuildPanelSettings", menuName = "ScriptableObjects/UI/Panels/BuildPanel", order = 0)]
    public class BuildPanelSettings : ScriptableObject, IBuildPanelSettings
    {
        [SerializeField] private BuildingUIDataTest building1;
        [SerializeField] private BuildingUIDataTest building2;
        [SerializeField] private BuildingUIDataTest building3;
        
        [SerializeField] private TextSettings textSettings1;
        [SerializeField] private TextSettings textSettings2;
        
        public IBuildingUIData Building1Data => building1;
        public IBuildingUIData Building2Data => building2;
        public IBuildingUIData Building3Data => building3;
        public IText PlacementModeText => textSettings1;
        public IText DestroyModeText => textSettings2;
    }

    [System.Serializable]
    public class BuildingUIDataTest : IBuildingUIData
    {
        [field: SerializeField] public Sprite BuildingImage { get; private set; }
        [field: SerializeField] public string BuildingName { get; private set; }
    }
}