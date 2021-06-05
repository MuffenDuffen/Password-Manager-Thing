using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string mPass = "testPassTestPassTTT";
            
            int[] encryptionKey = Profile.GetEncryptionKey(mPass);

            string encryptString = Encryptor.EncryptString(mPass, encryptionKey);
            string decryptString = Decryptor.DecryptString(encryptString, encryptionKey);
            
            Console.WriteLine("{0} {1}", encryptString, decryptString);
        }
    }
}