using UnityEngine;
using UnityEngine.UI;

namespace GridBuildSystem.UI
{
    public interface IBuildingUIData
    {
        Sprite BuildingImage { get; }
        string BuildingName { get; }
    }
    
    [CreateAssetMenu(fileName = "TextSettings", menuName = "ScriptableObjects/TextSettings", order = 0)]
    public class TextSettings : ScriptableObject, IText
    {
      [field: SerializeField]public string Text { get; private set; }
    }
}
