using System;
using System.Diagnostics;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();

            var test = "test";

            var encrypted = PythagoranTheorem.PTheoremWWords(test);
            var decrypted = PythagoranTheorem.ReversePTheoremWWords(encrypted);
            
            Console.WriteLine("{0}, {1}", encrypted, decrypted);
        }
    }
}