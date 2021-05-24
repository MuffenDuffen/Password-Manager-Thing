using System;
using System.Linq;

namespace PasswordManger
{
    public class Decryptor
    {
        public static Credential DecryptCredential(Credential credential, int[] key)
        {
            credential.AppName = DecryptString(credential.AppName, key);
            credential.Email = DecryptString(credential.Email, key);
            credential.Password = DecryptString(credential.Password, key);
            return credential;
        }

        private static string DecryptString(string decrypt, int[] key)
        {
            string decrypted = InvertBits(decrypt);
            decrypted = PreviousChar(decrypted);
            return decrypted;
        }
        
        // functions
        private static string PreviousChar(string masterPassword) // adds one to the UTF-8 value
        {
            foreach (char c in masterPassword)
            {
                var utf8ValueFromChar = Convert.ToUInt64(c);

                var charFromUtf8ValueAddOne = (char) (utf8ValueFromChar - 1);

                masterPassword = masterPassword.Replace(c, charFromUtf8ValueAddOne);
            }

            return masterPassword;
        }

        private static string InvertBits(string stringToInvert) // converts each characters UTF-8 value into bits and inverts it, then converts back to chars. China warning
        {
            var finalString = "";

            foreach (uint charValue in stringToInvert.Select(Convert.ToUInt32))
            {
                var charValueInBinary = Convert.ToString(charValue, 2);
                var charValueInBinaryArray = new char[charValueInBinary.Length];
                var indexInCharArray = 0;

                for (var i = 0; i < charValueInBinary.Length; i++) charValueInBinaryArray[i] = charValueInBinary[i];

                foreach (char cc in charValueInBinaryArray)
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