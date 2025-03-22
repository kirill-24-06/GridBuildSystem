using UnityEngine;

namespace GridBuildSystem.UI.Panels
{
    [CreateAssetMenu(fileName = "TextPanelSettings", menuName = "ScriptableObjects/UI/Panels/TextPanel", order = 1)]
    public class TextPanelSettings : ScriptableObject, ITextPanelSettings
    {
        [field: SerializeField]public TextSettings LeftTextSettings { get; private set; }
        [field: SerializeField]public TextSettings RightTextSettings { get; private set; }
    }
}
