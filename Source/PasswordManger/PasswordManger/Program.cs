using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();


            var cred = new Credential("test", "test", "test");
            Encryptor.EncryptCredential(cred, "test");
        }
    }
}