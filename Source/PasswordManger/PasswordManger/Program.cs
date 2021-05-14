using System;
using System.Text;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string possibleCharacters = "Hello";
            Console.WriteLine(Encryptor.toBinaryAndInvertBits(possibleCharacters));
        }
    }
}