using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IPlaceable
    {
        Transform Prefab { get; }
        
        void ChangeColor(bool canBePlaced);
        void OnPlaced();
    }
}