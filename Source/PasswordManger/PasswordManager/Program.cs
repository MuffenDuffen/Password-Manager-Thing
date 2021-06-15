using System;
using System.Linq;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();

            var mPass = "HAHAIaSAKBAD2";
            var passPhrase = "LoL" + Profile.GetPassPhrase(mPass);
            
            var encryptionKey = Profile.GetEncryptionKeyLOL(mPass);
            foreach (var key in encryptionKey) Console.WriteLine(key);
            var shift = Profile.GetShift(mPass);
            var cred = new Credential("testName", "testEmail", "testPass");
            var encryptedCred = Encryptor.EncryptCredential(cred, encryptionKey, shift, passPhrase);
            var decryptedCred = Decryptor.DecryptCredential(encryptedCred, encryptionKey, shift, passPhrase);
            
            Console.WriteLine(encryptedCred);
            Console.WriteLine("------------------");
            Console.WriteLine(decryptedCred.AppName);
            Console.WriteLine(decryptedCred.Email);
            Console.WriteLine(decryptedCred.Password);
        }
    }
}