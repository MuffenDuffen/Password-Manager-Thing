using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var cred = new Credential("GitHub", "test99480@gmail.com", "5IP1tGy50d8U");

            string encryptedCred = Encryptor.EncryptCredential(cred, new int[] {5});
            var decryptedCred = Decryptor.DecryptCredential(encryptedCred, new int[] {5});

            Console.WriteLine("{0} {1}", encryptedCred, decryptedCred.Password);
        }
    }
}