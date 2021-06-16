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
            for (var i = 0; i < text.Length; i++)
            {
                var charInInt = (long) text[i];
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
            var finalString = "";
            for (var i = 0; i < text.Length; i++)
            {
                var charInInt = (int) text[i];
                var charInIntInBinary = Convert.ToString(charInInt, 2).PadLeft(Dict[charInInt], '0');

                var reversedBinary = Encryptor.reverseString(charInIntInBinary);

                var reversedBinaryInInt = Convert.ToInt32(reversedBinary, 2);

                var reversedBinaryInIntChar = (char) reversedBinaryInInt;
                finalString += reversedBinaryInIntChar;
            }

            return finalString;
        }
    }
}
