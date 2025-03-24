using System.Collections.Generic;

namespace GridBuildSystem.BuildSystem.Buildings
{
    public interface IBuildingsSaveDataProvider
    {
        List<IBuildingSaveData> GetBuildingsSaveData();
    }
}