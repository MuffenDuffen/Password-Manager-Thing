using System;
using System.Diagnostics;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();

            var primeArray = PrimeConversionHelperFactory.GeneratePrimeList();

            Console.WriteLine(primeArray.Length);
        }
    }
}