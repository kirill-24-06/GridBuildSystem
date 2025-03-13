using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

namespace GridBuildSystem.Input
{
    
    [CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/Input/InputReader", order = 0)]
    public class InputReader : ScriptableObject, IInputReader
    {
        public event Action<Vector2> OnMousePositionChanged = delegate { };
        public event Action OnLeftMouseClick = delegate { };
        public event Action OnRightMouseClick = delegate { };

        public Vector2 MousePosition => _inputActions.Player.MousePositionChange.ReadValue<Vector2>();
        
        private InputActions _inputActions;

        public void EnableActionMap()
        {
            if (_inputActions == null)
            {
                _inputActions = new InputActions();

                _inputActions.Player.MousePositionChange.performed += OnMousePositionChange;
                _inputActions.Player.LeftClick.performed += OnLeftClick;
                _inputActions.Player.RightClick.performed += OnRightClick;
            }
            
            _inputActions.Enable();
        }

        public void DisableActionMap() => _inputActions?.Disable();

        private void OnMousePositionChange(InputAction.CallbackContext context) => OnMousePositionChanged.Invoke(context.ReadValue<Vector2>());
     
        private void OnLeftClick(InputAction.CallbackContext context) => OnLeftMouseClick.Invoke();

        private void OnRightClick(InputAction.CallbackContext context) => OnRightMouseClick.Invoke();
    }
}