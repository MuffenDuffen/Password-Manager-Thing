using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    public class PrimeStuff
    {
        private static readonly IReadOnlyDictionary<uint, uint> Dict = GetPrime();

        public static string EncryptToPrime(string encrypt)
        {
            var encryptArray = encrypt.ToCharArray();
            for (var i = 0; i < encryptArray.Length; i++)
            {
                encryptArray[i] = ToPrimeChar(encryptArray[i]);
            }

            return new string(encryptArray);
        }

        public static string DecryptFromPrime(string decrypt)
        {
            var decryptArray = decrypt.ToCharArray();
            for (var i = 0; i < decryptArray.Length; i++)
            {
                decryptArray[i] = FromPrimeChar(decryptArray[i]);
            }

            return new string(decryptArray);
        }

        private static char ToPrimeChar(char c)
        {
            return (char) Dict[c];
        }

        private static char FromPrimeChar(char c)
        {
            return (char) Dict.FirstOrDefault(x => x.Value == c).Key;
        }

        private static IReadOnlyDictionary<uint, uint> GetPrime()
        {
            var primeList = (new Eratosthenes(1000000)).ToArray();
            var dictionary = new Dictionary<uint, uint>();

            for (uint i = 0; i < 65535; i++)
            {
                dictionary.Add(i, primeList[i]);
            }

            return dictionary;
        }
    }
}
