namespace GridBuildSystem.SaveSystem
{
    public class XOREncryptor : IEncryptionUtility
    {
        private XOREncryptorSettings _settings;

        public XOREncryptor(XOREncryptorSettings settings)
        {
            _settings = settings;
        }
        
        public string Encrypt(string data) => EncryptDecrypt(data);
        public string Decrypt(string data) => EncryptDecrypt(data);

        private string EncryptDecrypt(string data)
        {
            var encryptedData = "";
            
            for (var i = 0; i < data.Length; i++)
            {
                encryptedData += (char)(data[i] ^ _settings.CodeWord[i % _settings.CodeWord.Length]);
            }
            
            return encryptedData;
        }
    }
}