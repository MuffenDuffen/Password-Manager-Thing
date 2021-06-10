using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal static class Decryptor
    {
        public static Credential DecryptCredential(string credentialString, int[] key, ulong shift)
        {
            var credential = new Credential("", "", "");

            var firstComma = credentialString.IndexOf(',', 0);
            var secondComma = credentialString.IndexOf(',', firstComma + 1);

            int appNameLength = Convert.ToInt16(credentialString[..firstComma]);

            int emailLength = Convert.ToInt16(credentialString.Substring(firstComma + 1, secondComma - firstComma - 1));

            int passwordLength = Convert.ToInt16(credentialString.Substring(secondComma + 1, credentialString.IndexOf(' ') - secondComma - 1));

            var encrypted = credentialString[(credentialString.IndexOf(' ') + 1)..];

            credential.AppName = encrypted[..appNameLength];
            credential.Email = encrypted.Substring(appNameLength, emailLength);

            credential.Password = encrypted.Substring(appNameLength + emailLength, passwordLength);


            credential.AppName = DecryptString(credential.AppName, key, shift);
            credential.Email = DecryptString(credential.Email, key, shift);
            credential.Password = DecryptString(credential.Password, key, shift);

            return credential;
        }

        private static string ReverseCaesarion(string decrypt, ulong shift)
        {
            var decryptArray = decrypt.ToCharArray();

            decryptArray = decryptArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar - shift)).ToArray();

            return decryptArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
        }

        private static string DecryptString(string decrypt, IEnumerable<int> key, ulong decryptShift) //ToDo mek function us key but reverse
        {
            foreach (var keyAtIndex in key.Reverse())
            {
                switch (keyAtIndex)
                {
                    case 0:
                        decrypt = PreviousChar(decrypt);
                        break;
                    case 1:
                        decrypt = Encryptor.InvertBits(decrypt);
                        break;
                    case 2:
                        decrypt = LatinizeLol.ReverseConvertStringToLatinNumber(decrypt);
                        break;
                    case 3:
                        decrypt = ReverseCaesarion(decrypt, decryptShift);
                        break;
                    case 4:
                        decrypt = RomanNumberStuff.RomanNumeralCalculator.ReverseConvertToRomanNumeral(decrypt);
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                }
            }

            return decrypt;
        }

        // functions
        private static string PreviousChar(string stringToPrevChar) // Removes one from the UTF-8 value
        {
            var prevCharArray = stringToPrevChar.ToCharArray();

            prevCharArray = prevCharArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar - 1)).ToArray();

            return prevCharArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
        }
    }
}
