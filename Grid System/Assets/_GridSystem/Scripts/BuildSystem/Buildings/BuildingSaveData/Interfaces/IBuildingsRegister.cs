namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IBuildingsRegister
    {
        void Register(IBuilding building);
        void Unregister(IBuilding building);
    }
}