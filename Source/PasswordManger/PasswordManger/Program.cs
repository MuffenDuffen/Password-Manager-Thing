using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();


            var cred = new Credential("test", "test", "test");
            var lol = Encryptor.EncryptCredential(cred, new[] {0});
            Console.WriteLine(Decryptor.DecryptCredential(lol, new[] {0}).Password);
        }
    }
}