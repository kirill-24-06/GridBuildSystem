using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    [CreateAssetMenu(fileName = "BuildSystem", menuName = "ScriptableObjects/BuildSystem/Buildings", order = 0)]
    public class BuildingSettings : ScriptableObject, IBuildingSettings
    {
        [field: SerializeField] public Transform Prefab { get; private set; }
        [field: SerializeField] public Sprite BuildingImage { get; private set; }
        [field: SerializeField] public string BuildingName { get; private set; }
        [field: SerializeField] public Vector3Int Size { get; private set; } = Vector3Int.zero;
        [field: SerializeField] public Color AvailableColor { get; private set; } = Color.green;
        [field: SerializeField] public Color UnavailableColor { get; private set; } = Color.red;
        [field: SerializeField] public Color DefaultColor { get; private set; } = Color.white;


        public IBuilding CreateBuilding()
        {
             var go = Instantiate(Prefab.gameObject);
             var renderer = go.GetComponentInChildren<Renderer>();
             go.name = BuildingName;

             var building = new Building(this);
             building.Initialize(go.transform, renderer);
             
             return building;
        }
    }
}