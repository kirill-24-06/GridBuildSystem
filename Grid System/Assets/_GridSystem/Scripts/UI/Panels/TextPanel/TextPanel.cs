using UnityEngine;
using TMPro;
namespace GridBuildSystem.UI.Panels
{
    public class TextPanel : MonoBehaviour,IPanel
    {
        [SerializeField] private TextMeshProUGUI _leftText;
        [SerializeField] private TextMeshProUGUI _rightText;

        public void Construct(ITextPanelSettings settings)
        {
            _leftText.text = settings.LeftTextSettings.Text;
            _rightText.text = settings.RightTextSettings.Text;
        }

        public void Hide() => gameObject.SetActive(false);
        public void Show() => gameObject.SetActive(true);
    }
}
