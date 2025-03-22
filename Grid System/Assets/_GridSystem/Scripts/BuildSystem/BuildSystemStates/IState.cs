namespace GridBuildSystem.BuildSystem
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}