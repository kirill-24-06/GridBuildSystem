using System;
using UnityEngine;

namespace GridBuildSystem.Input
{
    public interface IInputReader
    {
        public event Action<Vector2> OnMousePositionChanged ;
        public event Action OnLeftMouseClick;
        public event Action OnRightMouseClick ;

        public Vector2 MousePosition { get; }
        
        void EnableActionMap();
        void DisableActionMap();
    }
}