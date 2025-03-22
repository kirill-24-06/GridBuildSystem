using UnityEngine;

namespace GridBuildSystem.SaveSystem
{
    public interface IStorable
    {
        Vector3Int Position { get; }
        string Name { get; }
    }

}
