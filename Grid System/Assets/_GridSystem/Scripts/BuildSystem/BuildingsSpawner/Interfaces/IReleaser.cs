using GridBuildSystem.BuildSystem.Buildings;

namespace GridBuildSystem.BuildSystem
{
    public interface IReleaser
    {
        void Release(IBuilding building);
    }
}