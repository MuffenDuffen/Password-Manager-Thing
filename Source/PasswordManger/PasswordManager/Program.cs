using System;
using System.Diagnostics;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();

            var mPass = "HAHAIaSAKBAD2";
            var passPhrase = "LoL" + Profile.GetPassPhrase(mPass);

            var encryptionKey = Profile.GetEncryptionKey(mPass);
            var shift = Profile.GetShift(mPass);

            var cred = new Credential("testAppName", "testEmail", "testPass");
            
            var eC = Encryptor.EncryptCredential(cred, encryptionKey, shift, passPhrase);
            var dC = Decryptor.DecryptCredential(eC, encryptionKey, shift, passPhrase);

            Console.WriteLine(dC.AppName);
            Console.WriteLine(dC.Email);
            Console.WriteLine(dC.Password);
        }
    }
}