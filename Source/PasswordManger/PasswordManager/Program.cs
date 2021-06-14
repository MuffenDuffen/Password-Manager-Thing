using System;
using System.Diagnostics;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();
            
            var mPass = "HAHAISAKBAD2";
            var encryptionKey = Profile.GetEncryptionKey(mPass);

            var shift = Profile.GetShift(mPass);

            var cred = new Credential("test", "test1", "test2");

            var encryptedCred = Encryptor.EncryptCredential(cred, encryptionKey, shift);
            var decryptedCred = Decryptor.DecryptCredential(encryptedCred, encryptionKey, shift);

            Console.WriteLine(decryptedCred.AppName);
            Console.WriteLine(decryptedCred.Email);
            Console.WriteLine(decryptedCred.Password);
        }
    }
}