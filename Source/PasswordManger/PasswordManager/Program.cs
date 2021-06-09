using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();
            const string mPass = "testPassTestPassTtT";

            var encryptionKey = Profile.GetEncryptionKey(mPass);
            foreach (var key in encryptionKey) Console.WriteLine(key);
        }
    }
}