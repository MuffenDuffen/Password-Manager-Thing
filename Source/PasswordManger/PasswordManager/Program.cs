using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string mPass = "testPassTestPassTTT";
            
            int[] encryptionKey = Profile.GetEncryptionKey(mPass);
            ulong shift = Profile.GetShift(mPass);

            string encryptString = Encryptor.EncryptString(mPass, encryptionKey, shift);
            string decryptString = Decryptor.DecryptString(encryptString, encryptionKey, shift);
            
            Console.WriteLine("{0} {1}", encryptString, decryptString);
        }
    }
}