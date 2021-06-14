using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class Fibonacci
    {
        private static readonly IReadOnlyDictionary<int, ulong> Dict = GetFibonacci();

        public static string EncryptToFibonacci(string encrypt)
        {
            var encryptArray = encrypt.ToCharArray();
            for (var i = 0; i < encryptArray.Length; i++)
            {
                encryptArray[i] = ToFibonacciChar(encryptArray[i]);
            }

            return new string(encryptArray);
        }

        public static string DecryptFromFibonacci(string decrypt)
        {
            var decryptArray = decrypt.ToCharArray();
            for (var i = 0; i < decryptArray.Length; i++)
            {
                decryptArray[i] = FromFibonacciChar(decryptArray[i]);
            }

            return new string(decryptArray);
        }

        private static char ToFibonacciChar(char c)
        {
            return (char) Dict[c];
        }

        private static char FromFibonacciChar(char c)
        {
            return (char) Dict.FirstOrDefault(x => x.Value == c).Key;
        }

        public static IReadOnlyDictionary<int, ulong> GetFibonacci()
        {
            var dictionary = new Dictionary<int, ulong>();

            ulong a = 0, b = 1;
            for (var i = 2; i < 65535; i++)
            {
                var c = a + b;
                dictionary.Add(i, c % 65535);
                a = b;
                b = c;
            }

            return dictionary;
        }
    }
}