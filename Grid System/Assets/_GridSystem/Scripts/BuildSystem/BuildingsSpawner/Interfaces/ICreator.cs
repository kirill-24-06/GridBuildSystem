using GridBuildSystem.BuildSystem.Buildings;

namespace GridBuildSystem.BuildSystem
{
    public interface ICreator
    {
        IBuilding Create();
    }
}