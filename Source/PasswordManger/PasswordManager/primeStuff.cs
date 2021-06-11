using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class PrimeEncryptDecryptMethods
    {
        public static string EncryptPrimeWord(string word)
        {
            var finalString = "";

            foreach (var c in word)
            {
                finalString += EncryptPrimeChar(c, PrimeDictionaryCreationMethods.DictionaryWithNumbersAsIndex(PrimeListGenerator.GeneratePrimeList()));
            }

            return finalString;
        }

        public static string DecryptPrimeWord(string word)
        {
            var finalString = "";

            foreach (var c in word)
            {
                finalString += DecryptPrimeChar(c, PrimeDictionaryCreationMethods.DictionaryWithPrimesAsIndex(PrimeListGenerator.GeneratePrimeList()));
            }

            return finalString;
        }

        private static char EncryptPrimeChar(char c, Dictionary<uint, uint> dict)
        {
            var finalChar = (char) dict[c];

            return finalChar;
        }

        private static char DecryptPrimeChar(char c, Dictionary<uint, uint> dict)
        {
            var finalChar = (char) dict[c];

            return finalChar;
        }
    }

    internal static class PrimeDictionaryCreationMethods
    {
        public static Dictionary<uint, uint> DictionaryWithNumbersAsIndex(uint[] primesList)
        {
            var dictionary = new Dictionary<uint, uint>();

            for (uint i = 0; i < primesList.Length; i++)
            {
                dictionary[i] = primesList[i];
            }

            return dictionary;
        }

        public static Dictionary<uint, uint> DictionaryWithPrimesAsIndex(uint[] primesList)
        {
            var dictionary = new Dictionary<uint, uint>();

            for (uint ii = 0; ii < primesList.Length; ii++)
            {
                dictionary[primesList[ii]] = (uint) ii;
            }

            return dictionary;
        }
    }

    internal static class PrimeListGenerator
    {
        public static uint[] GeneratePrimeList()
        {
            var primesList = new Eratosthenes(10000, true);

            return primesList.ToArray();
        }
    }
}