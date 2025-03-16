using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GridBuildSystem.UI.Panels
{
    public class BuildPanel : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _building1Button;
        [SerializeField] private Button _building2Button;
        [SerializeField] private Button _building3Button;

        [SerializeField] private Button _placementModeButton;
        [SerializeField] private Button _destroyModeButton;
        
        private IBuildPanelSettings _settings;

        public event Action<string> OnBuildingChoose = delegate { };
        public event Action OnPlacementModeActive = delegate { };
        public event Action OnDestroyModeActive = delegate { };

        public void Construct(IBuildPanelSettings settings)
        {
            _settings = settings;
            
            _building1Button.image.sprite = _settings.Building1Data.BuildingImage;
            _building2Button.image.sprite = _settings.Building2Data.BuildingImage;
            _building3Button.image.sprite = _settings.Building3Data.BuildingImage;

            _placementModeButton.GetComponentInChildren<TextMeshProUGUI>().text = _settings.PlacementModeText.Text;
            _destroyModeButton.GetComponentInChildren<TextMeshProUGUI>().text = _settings.DestroyModeText.Text;
            
            _building1Button.onClick.AddListener(() => OnBuildingChoose.Invoke(_settings.Building1Data.BuildingName));
            _building2Button.onClick.AddListener(() => OnBuildingChoose.Invoke(_settings.Building2Data.BuildingName));
            _building3Button.onClick.AddListener(() => OnBuildingChoose.Invoke(_settings.Building3Data.BuildingName));
            
            _placementModeButton.onClick.AddListener(() => OnPlacementModeActive.Invoke());
            _destroyModeButton.onClick.AddListener(() => OnDestroyModeActive.Invoke());
        }

        public void Hide() => gameObject.SetActive(false);
        
        public void Show() => gameObject.SetActive(true);
       
        private void OnDestroy()
        {
            _building1Button.onClick.RemoveAllListeners();
            _building2Button.onClick.RemoveAllListeners();
            _building3Button.onClick.RemoveAllListeners();
            _placementModeButton.onClick.RemoveAllListeners();
            _destroyModeButton.onClick.RemoveAllListeners();
        }
    }
}