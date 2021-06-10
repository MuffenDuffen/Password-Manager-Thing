using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class PrimeStuff
    {
        public static string ConvertWordToPrimeAtThatIndexToChar(string word)
        {
            return word.Aggregate("", (current, c) => current + ConvertCharToPrimeAtThatIndexToChar(c));
        }

        public static string ReverseConvertWordToPrimeAtThatIndexToChar(string word)
        {
            return word.Aggregate("", (current, c) => current + ReverseConvertCharToPrimeAtThatIndex(c));
        }

        private static char ConvertCharToPrimeAtThatIndexToChar(char c)
        {
            var primeDictionary = new Dictionary<ulong, ulong>();

            var primeArray = new Eratosthenes(10000, true);
            ulong indexInArray = 0;

            foreach (var prime in primeArray)
            {
                primeDictionary[indexInArray] = prime;
                indexInArray++;
            }

            indexInArray = 0;

            return (char) primeDictionary[c];
        }

        private static char ReverseConvertCharToPrimeAtThatIndex(char c)
        {
            var primeDictionary = new Dictionary<ulong, ulong>();

            var primeArray = new Eratosthenes(10000, true);
            ulong indexInArray = 0;

            foreach (var prime in primeArray)
            {
                primeDictionary[prime] = indexInArray;
                indexInArray++;
            }

            indexInArray = 0;

            return (char) primeDictionary[c];
        }
    }
}
