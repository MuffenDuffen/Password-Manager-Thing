using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class PrimeConversionHelperFactory
    {
        internal static uint[] GeneratePrimeList()
        {
            var primeArray = new Eratosthenes(821610, true);

            var array = primeArray.ToArray();

            return array;
        }

        internal static Dictionary<uint, uint> CreateDictionaryWithNumbersAsKey(uint[] primeList)
        {
            var dictionary = new Dictionary<uint, uint>();

            for (uint i = 0; i < primeList.Length; i++)
            {
                dictionary[i] = primeList[i];
            }

            return dictionary;
        }

        internal static Dictionary<uint, uint> CreateDictionaryWithPrimesAsKey(Dictionary<uint, uint> dictionaryWithNumbersAsKey)
        {
            var dictionary = new Dictionary<uint, uint>();

            foreach (var pair in dictionaryWithNumbersAsKey)
            {
                dictionary[pair.Value] = pair.Key;
            }

            return dictionary;
        }
    }

    internal static class PrimeConversionMethodWithCharsFactory
    {
        public static char EncryptPrimeChar(char c, Dictionary<uint, uint> dict)
        {
            var finalChar = (char) dict[c];

            return finalChar;
        }

        public static char DecryptPrimeChar(char c, Dictionary<uint, uint> dict)
        {
            var finalChar = (char) dict[c];

            return finalChar;
        }
    }

    internal static class PrimeConversionMethodWithWordsFactory
    {
        public static string EncryptPrimeWord(string word, Dictionary<uint, uint> dict)
        {
            var finalString = "";

            foreach (var c in word) finalString += (char) PrimeConversionMethodWithCharsFactory.EncryptPrimeChar(c, dict);

            return finalString;
        }

        public static string DecryptPrimeWord(string word, Dictionary<uint, uint> dict)
        {
            var finalString = "";

            foreach (var c in word) finalString += (char) PrimeConversionMethodWithCharsFactory.DecryptPrimeChar(c, dict);

            return finalString;
        }
    }
}