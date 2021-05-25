using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();
            Console.WriteLine(MegaEncryptorThatIsakHatesLol.Encrypt("Hello, world!", "testPass"));
        }
    }
}