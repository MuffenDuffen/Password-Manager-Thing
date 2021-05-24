using System;
using System.Collections;
using System.Linq;

namespace PasswordManger
{
    internal static class Encryptor
    {
        public static string EncryptCredential(Credential credential, int[] key)
        {
            var encrypted = EncryptString(credential.AppName, key) + EncryptString(credential.Email, key) + EncryptString(credential.Password, key);
            return encrypted;
        }

        private static string EncryptString(string encrypt, int[] key) //ToDo mek function us key
        {
            var encrypted = NextChar(encrypt);
            encrypted = InvertBits(encrypted);
            return encrypted;
        }
        //Gets next char and replaces old one

        //encryptions, replacecharwithnextchar, toandinvertbinary, tooctal

        private static string NextChar(string masterPassword) // adds one to the UTF-8 value
        {
            foreach (var c in masterPassword)
            {
                var utf8ValueFromChar = Convert.ToUInt64(c);

                var charFromUtf8ValueAddOne = (char) (utf8ValueFromChar + 1);

                masterPassword = masterPassword.Replace(c, charFromUtf8ValueAddOne);
            }

            return masterPassword;
        }

        private static string InvertBits(string stringToInvert) // converts each characters UTF-8 value into bits and inverts it, then converts back to chars. China warning
        {
            var finalString = "";

            foreach (var charValue in stringToInvert.Select(Convert.ToUInt32))
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

            stringToInvert = finalString;
            return stringToInvert;
        }
    }
}