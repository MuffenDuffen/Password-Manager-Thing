using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    public class Fibonacci
    {
        private static readonly IReadOnlyDictionary<int, int> Dict = GetFibonacci();
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

        private static IReadOnlyDictionary<int, int> GetFibonacci()
        {
            var dictionary = new Dictionary<int, int>();

            var fib = 1;
            for (var i = 0; i < 65535; i++)
            {
                var temp = fib;
                fib += fib; 
                dictionary.Add(i, temp);
            }

            return dictionary;
        }
    }
}