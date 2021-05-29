using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string encryptedString = Encryptor.InvertBits(Encryptor.NextChar("test"));
            
            string decrytedString = Decryptor.PreviousChar(Encryptor.InvertBits(encryptedString));


            Console.WriteLine("{0} {1}", encryptedString, decrytedString);
        }
    }
}