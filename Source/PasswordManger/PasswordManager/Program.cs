using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var cred = new Credential("Hqweelo", "Wqweorqweld", "qweIqwe");
            
            string encryptedCred = Encryptor.EncryptCredential(cred, new int[] {5});
            var decryptedCred = Decryptor.DecryptCredential(encryptedCred, new int[] {5});

            Console.WriteLine(encryptedCred);
            Console.WriteLine(decryptedCred.AppName);
        }
    }
}