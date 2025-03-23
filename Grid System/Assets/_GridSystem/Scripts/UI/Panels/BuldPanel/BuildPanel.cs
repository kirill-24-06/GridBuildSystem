using System;
using GridBuildSystem.BuildSystem.Buildings;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GridBuildSystem.UI.Panels
{
    public class BuildPanel : MonoBehaviour, IPanel
    {
        [SerializeField] private Button[] _buildingButtons;

        [SerializeField] private Button _placementModeButton;
        [SerializeField] private Button _destroyModeButton;
        
        public event Action<string> OnBuildingChoose = delegate { };
        public event Action OnPlacementModeActive = delegate { };
        public event Action OnDestroyModeActive = delegate { };

        public void Construct(IBuildPanelSettings settings, IBuildingUIData[] buildings)
        {

            for (var i = 0; i < _buildingButtons.Length; i++)
            {
                _buildingButtons[i].image.sprite = buildings[i].BuildingImage;
                
                var j = i;
                
                _buildingButtons[i].onClick.AddListener(() => OnBuildingChoose.Invoke(buildings[j].BuildingName));
            }
            
            _placementModeButton.GetComponentInChildren<TextMeshProUGUI>().text = settings.PlacementModeText.Text;
            _destroyModeButton.GetComponentInChildren<TextMeshProUGUI>().text = settings.DestroyModeText.Text;
            
            _placementModeButton.onClick.AddListener(() => OnPlacementModeActive.Invoke());
            _destroyModeButton.onClick.AddListener(() => OnDestroyModeActive.Invoke());
        }

        public void Hide() => gameObject.SetActive(false);
        
        public void Show() => gameObject.SetActive(true);
       
        private void OnDestroy()
        {
            foreach (var button in _buildingButtons)
            {
                button.onClick.RemoveAllListeners();
            }
            _placementModeButton.onClick.RemoveAllListeners();
            _destroyModeButton.onClick.RemoveAllListeners();
        }
    }
}