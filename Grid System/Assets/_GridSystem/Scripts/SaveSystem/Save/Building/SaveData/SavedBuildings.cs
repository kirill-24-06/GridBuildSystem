using System;

namespace GridBuildSystem.SaveSystem
{
    [Serializable]
    public struct SavedBuildings: ISaveData
    {
        public BuildingSaveData[] Buildings;
    }
}