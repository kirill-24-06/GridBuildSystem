using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    [CreateAssetMenu(fileName = "BuildSystem", menuName = "ScriptableObjects/BuildSystem/Buildings", order = 0)]
    public class BuildingSettings : ScriptableObject, IBuildingSettings
    {
        [field: SerializeField] public Transform Prefab { get; private set; }
        [field: SerializeField] public Vector3Int Size { get; private set; } = Vector3Int.zero;
        [field: SerializeField] public Color AvailableColor { get; private set; } = Color.green;
        [field: SerializeField] public Color UnavailableColor { get; private set; } = Color.red;
        [field: SerializeField] public Color DefaultColor { get; private set; } = Color.white;


        public IBuilding CreateBuilding() => new Building(this);
    }
}