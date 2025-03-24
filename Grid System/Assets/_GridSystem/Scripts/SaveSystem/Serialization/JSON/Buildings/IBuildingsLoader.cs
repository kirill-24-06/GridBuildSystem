using GridBuildSystem.SaveSystem;

namespace GridBuildSystem.LoadSystem
{
    public interface IBuildingsLoader
    {
        bool LoadBuildings(out SavedBuildings savedBuildings);
    }
}