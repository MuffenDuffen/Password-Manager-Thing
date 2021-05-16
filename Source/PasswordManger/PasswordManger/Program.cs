using System;
using System.Text;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            foreach (var c in Encryptor.ConvertToBinaryThenInvertBitsAndBackToString("Jag är best!"))
            {
                Console.WriteLine(Convert.ToInt64(c));
            }
        }
    }
}