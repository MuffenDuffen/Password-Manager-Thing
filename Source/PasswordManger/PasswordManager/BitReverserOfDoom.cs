using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class BitReverserOfDoom
    {
        private static readonly Dictionary<int, int> Dict = new();

        public static string ReverseLol(string text)
        {
            var finalString = "";
            foreach (var t in text)
            {
                var charInInt = (long) t;
                var charInIntInBinary = Convert.ToString(charInInt, 2);

                var reversedBinary = Encryptor.reverseString(charInIntInBinary);
                var length = reversedBinary.Length;

                if (!Dict.ContainsKey(Convert.ToInt32(reversedBinary, 2)))
                {
                    Dict.Add(Convert.ToInt32(reversedBinary, 2), length);
                }

                var reversedBinaryInInt = Convert.ToInt32(reversedBinary, 2);

                var reversedBinaryInIntChar = (char) reversedBinaryInInt;
                finalString += reversedBinaryInIntChar;
            }

            return finalString;
        }

        public static string ReveseReverseLol(string text)
        {
            return (from t in text select (int) t into charInInt select Convert.ToString(charInInt, 2).PadLeft(Dict[charInInt], '0') into charInIntInBinary select Encryptor.reverseString(charInIntInBinary) into reversedBinary select Convert.ToInt32(reversedBinary, 2) into reversedBinaryInInt select (char) reversedBinaryInInt).Aggregate("", (current, reversedBinaryInIntChar) => current + reversedBinaryInIntChar);
        }

        public static string ReverseBitOrder(string encrypt)
        {
            var encrypted = "";
            foreach (var c in encrypt)
            {
                var binary = Convert.ToString(c, 2);
                while (binary.Length < 16) binary = binary.Insert(0, "0");

                binary = Encryptor.reverseString(binary);
                encrypted += (char) Convert.ToInt32(binary, 2);
            }
            return encrypted;
        }
    }
}
