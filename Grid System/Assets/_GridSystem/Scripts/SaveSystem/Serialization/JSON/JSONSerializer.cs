using System.IO;
using UnityEngine;

namespace GridBuildSystem.SaveSystem
{
    public class JSONSerializer: ISerializer
    {
        private readonly string _path;

        private readonly IEncryptor _encryptor;

        public JSONSerializer(IEncryptor encryptor,string path = "/save.json")
        {
            _encryptor = encryptor;
            _path = path;
        }
        
        public void Serialize(ISaveData data)
        {
            var json = JsonUtility.ToJson(data, true);

            var encrypt = _encryptor.Encrypt(json);
            
            var path = Application.persistentDataPath + _path;
            
            File.WriteAllText(path, encrypt);
        }
    }
}