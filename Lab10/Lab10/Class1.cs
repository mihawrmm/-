using System;
using System.Security.Cryptography;
using System.Text;

namespace MyCryptography
{
    public class BlowfishAlgorithm
    {
        // Метод для шифрування даних з використанням BLOWFISH
        public byte[] Encrypt(byte[] data, byte[] key)
        {
            using (var algorithm = new Blowfish())
            {
                algorithm.Initialize(key);
                return algorithm.Encrypt_CBC(data);
            }
        }

        // Метод для розшифрування даних з використанням BLOWFISH
        public byte[] Decrypt(byte[] encryptedData, byte[] key)
        {
            using (var algorithm = new Blowfish())
            {
                algorithm.Initialize(key);
                return algorithm.Decrypt_CBC(encryptedData);
            }
        }
    }
}
