using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var cred = new Credential("Hqweello", "Wqweorqweld", "qweIqwe");
            
            string encryptedCred = Encryptor.EncryptCredential(cred, new int[] {5});
            var decryptedCred = Decryptor.DecryptCredential(encryptedCred, new int[] {5});
        }
    }
}