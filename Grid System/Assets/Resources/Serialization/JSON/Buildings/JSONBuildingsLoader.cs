using System.IO;
using GridBuildSystem.SaveSystem;
using UnityEngine;

namespace GridBuildSystem.LoadSystem
{
    public class JSONBuildingsLoader : IBuildingsLoader
    {
        private readonly string _path;
        
        private readonly IDecryptor _decryptor;

        public JSONBuildingsLoader(IDecryptor decryptor ,string path = "/save.json")
        {
            _decryptor = decryptor;
            _path = path;
        }

        public bool LoadBuildings(out SavedBuildings savedBuildings)
        {
            var path = Application.persistentDataPath + _path;

            savedBuildings = default;

            if (!File.Exists(path)) return false;

            var text = File.ReadAllText(path);

            var json = _decryptor.Decrypt(text);

            var data = JsonUtility.FromJson<SavedBuildings>(json);

            savedBuildings = data;

            return true;
        }
    }
}