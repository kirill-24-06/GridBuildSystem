using UnityEngine;

namespace GridBuildSystem.SaveSystem
{
    [CreateAssetMenu(fileName = "Encryptor Settings", menuName = "ScriptableObjects/Cryptography/XOR", order = 0)]
    public class XOREncryptorSettings: ScriptableObject
    {
        [field: SerializeField] public string CodeWord { get; private set; } = "word";
    }
}