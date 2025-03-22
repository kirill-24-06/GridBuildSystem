using System;
using GridBuildSystem.BuildSystem.Buildings;
using GridBuildSystem.Grid;
using GridBuildSystem.Input;
using UnityEngine;

namespace GridBuildSystem.BuildSystem
{
    public abstract class BuildSystemMode : IState
    {
        protected GridMode<IBuilding> _grid;
        protected Camera _camera;
        protected IInputReader _input;

        public event Action OnEnter = delegate { };
        public event Action OnExit = delegate { };

        public virtual void Enter()
        {
            OnEnter.Invoke();
        }

        public virtual void Exit()
        {
            OnExit.Invoke();
        }
    }
}