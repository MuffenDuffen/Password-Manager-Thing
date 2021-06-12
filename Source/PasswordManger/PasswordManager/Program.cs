using System;
using System.Diagnostics;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            var reversedDict = PrimeConversionHelperFactory.CreateDictionaryWithPrimesAsKey(PrimeConversionHelperFactory.CreateDictionaryWithNumbersAsKey(PrimeConversionHelperFactory.GeneratePrimeList()));
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            Console.WriteLine(ts);
        }
    }
}