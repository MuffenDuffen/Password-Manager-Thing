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
            var primesList = new Eratosthenes(10000, true);

            var primesListArray = primesList.ToArray();

            return primesListArray;
        }
    }

    internal static class PrimeFunctions
    {
        internal static char CharToCharAtIndexOfPrime(char c)
        {
            var primesList = PrimeList.GetPrimeList();
            var primeDictionaryWithNumbersAsIndex = new Dictionary<ulong, ulong>();

            for (ulong i = 0; i < (ulong) primesList.Length; i++)
            {
                primeDictionaryWithNumbersAsIndex[i] = primesList[i];
            }

            var finalChar = (char) primeDictionaryWithNumbersAsIndex[c];

            return finalChar;
        }

        internal static char ReverseCharToCharAtIndexOfPrime(char c)
        {
            var primesList = PrimeList.GetPrimeList();

            var primeDictionaryWithPrimesAsIndex = new Dictionary<ulong, int>();

            for (var i = 0; i < primesList.Length; i++)
            {
                primeDictionaryWithPrimesAsIndex[primesList[i]] = i;
            }

            var finalChar = (char) primeDictionaryWithPrimesAsIndex[c];

            return finalChar;
        }
    }
}
