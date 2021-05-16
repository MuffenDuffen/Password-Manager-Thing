using System;
using System.Collections;
using System.Linq;

namespace PasswordManger
{
    internal static class Encryptor
    {
        //Gets next char and replaces old one

        //encryptions, replacecharwithnextchar, toandinvertbinary, tooctal

        internal static string addOneToUTF8value(string masterPassword)
        {
            foreach (var c in masterPassword)
            {
                var utf8ValueFromChar = Convert.ToUInt64(c);

                var charFromUtf8ValueAddOne = (char) (utf8ValueFromChar + 1);

                masterPassword = masterPassword.Replace(c, charFromUtf8ValueAddOne);
            }

            return masterPassword;
        }

        public static string ConvertToBinaryThenInvertBitsAndBackToString(string stringToReverseBits)
        {
            var finalString = "";

            foreach (var charValue in stringToReverseBits.Select(Convert.ToUInt32))
            {
                var charValueInBinary = Convert.ToString(charValue, 2);
                var charValueInBinaryArray = new char[charValueInBinary.Length];
                var indexInCharArray = 0;

                for (var i = 0; i < charValueInBinary.Length; i++) charValueInBinaryArray[i] = charValueInBinary[i];

                foreach (var cc in charValueInBinaryArray)
                {
                    charValueInBinaryArray[indexInCharArray] = cc switch
                    {
                        '1' => '0',
                        '0' => '1',
                        _ => charValueInBinaryArray[indexInCharArray]
                    };
                    indexInCharArray++;
                }

                var charFromInvertedBinary = (char) Convert.ToUInt64(charValueInBinary);
                finalString = finalString.Insert(0, charFromInvertedBinary.ToString());
            }

            stringToReverseBits = finalString;
            return stringToReverseBits;
        }

        public static string pSats(string inputString)
        {
            var lengthOfString = inputString.Length;
            
            
        }
    }
}