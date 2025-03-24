using System.IO;
using GridBuildSystem.SaveSystem;
using UnityEngine;

namespace GridBuildSystem.LoadSystem
{
    public class JSONDeserializer : IDeserializer
    {
        private readonly string _path;
        
        private readonly IDecryptor _decryptor;

        public JSONDeserializer(IDecryptor decryptor, string path = "/save.json")
        {
            _path = path;
            _decryptor = decryptor;
        }
        
        public bool Deserialize<T>(out T data)
        {
            var path = Application.persistentDataPath + _path;

            data = default;

            if (!File.Exists(path)) return false;

            var text = File.ReadAllText(path);

            var json = _decryptor.Decrypt(text);

            var jsonData = JsonUtility.FromJson<T>(json);

            data = jsonData;

            return true;
        }
    }
}