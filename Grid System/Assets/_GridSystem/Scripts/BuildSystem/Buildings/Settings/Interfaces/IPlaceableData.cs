using UnityEngine;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IPlaceableData
    {
        Color AvailableColor { get; }
        Color UnavailableColor { get; }
        Color DefaultColor { get; }
    }
}