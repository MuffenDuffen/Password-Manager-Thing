using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class PrimeStuff
    {
        public static string ConvertWordToPrimeAtThatIndexToChar(string word)
        {
            return word.Aggregate("", (current, c) => current + PrimeFunctions.CharToCharAtIndexOfPrime(c));
        }

        public static string ReverseConvertWordToPrimeAtThatIndexToChar(string word)
        {
            return word.Aggregate("", (current, c) => current + PrimeFunctions.ReverseCharToCharAtIndexOfPrime(c));
        }
    }

    internal static class PrimeList
    {
        internal static uint[] GetPrimeList()
        {
            var primesList = new Eratosthenes(1000000, true);

            var primesListArray = primesList.ToArray();

            return primesListArray;
        }

        internal static Dictionary<ulong, ulong> getPrimeListWithNumberAsIndex(uint[] primesList)
        {
            var primeDictionaryWithNumbersAsIndex = new Dictionary<ulong, ulong>();

            for (ulong i = 0; i < (ulong) primesList.Length; i++)
            {
                primeDictionaryWithNumbersAsIndex[i] = primesList[i];
            }

            return primeDictionaryWithNumbersAsIndex;
        }

        internal static Dictionary<ulong, int> getPrimeListWithPrimesAsIndex(uint[] primesList)
        {
            var primeDictionaryWithPrimesAsIndex = new Dictionary<ulong, int>();

            for (var i = primesList.Length - 1; i >= 0; i--)
            {
                primeDictionaryWithPrimesAsIndex[primesList[i]] = i;
            }

            return primeDictionaryWithPrimesAsIndex;
        }
    }

    internal static class PrimeFunctions
    {
        internal static char CharToCharAtIndexOfPrime(char c)
        {
            var primesList = PrimeList.GetPrimeList();
            var dictionary = PrimeList.getPrimeListWithNumberAsIndex(primesList);

            var finalChar = (char) dictionary[c];

            return finalChar;
        }

        internal static char ReverseCharToCharAtIndexOfPrime(char c)
        {
            var primesList = PrimeList.GetPrimeList();
            var dictionary = PrimeList.getPrimeListWithPrimesAsIndex(primesList);

            var finalChar = (char) dictionary[c];

            return finalChar;
        }
    }
}
