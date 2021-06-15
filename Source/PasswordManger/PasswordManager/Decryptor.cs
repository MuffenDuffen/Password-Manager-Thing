using System;
using System.Linq;

namespace PasswordManger
{
    internal static class Decryptor
    {
        public static Credential DecryptCredential(string credentialString, int[] key, ulong shift, string passPhrase)
        {
            var credential = new Credential("", "", "");

            var firstComma = credentialString.IndexOf(',', 0);
            var secondComma = credentialString.IndexOf(',', firstComma + 1);

            var appNameLength = Convert.ToInt32(credentialString[..firstComma]);

            var emailLength = Convert.ToInt32(credentialString.Substring(firstComma + 1, secondComma - firstComma - 1));

            var passwordLength = Convert.ToInt32(credentialString.Substring(secondComma + 1, credentialString.IndexOf(' ') - secondComma - 1));

            var encrypted = credentialString[(credentialString.IndexOf(' ') + 1)..];

            credential.AppName = encrypted[..appNameLength];
            credential.Email = encrypted.Substring(appNameLength, emailLength);
            credential.Password = encrypted.Substring(appNameLength + emailLength, passwordLength);

            credential.AppName = Decryptor.DecryptString(credential.AppName, key, shift, passPhrase);
            credential.Email = Decryptor.DecryptString(credential.Email, key, shift, passPhrase);
            credential.Password = Decryptor.DecryptString(credential.Password, key, shift, passPhrase);
            return credential;
        }

        public static string DecryptString(string decrypt, int[] key, ulong decryptShift, string passPhrase) //ToDo mek function us key but reverse
        {
            var result = decrypt;
            foreach (var i in key.Reverse())
                result = i switch
                {
                    0 => PreviousChar(result),
                    1 => Encryptor.InvertBits(result),
                    2 => LatinizeLol.ReverseConvertStringToLatinNumber(result),
                    3 => ReverseCaesarion(result, decryptShift),
                    4 => RomanNumberStuff.RomanNumeralCalculator.ReverseConvertToRomanNumeral(result),
                    5 => HexStuff.reverseWordToHex(result),
                    6 => ReverseCharAdder(result, passPhrase),
                    7 => PythagoranTheorem.ReversePTheoremWWords(result),
                    8 => Encryptor.reverseString(result),
                    9 => StringLolifierlol.ReverseLOLIFIERLOL(result),
                    10 => CircumferenceStuff.ReverseGetCircumferenceOfCharWithEntireText(result),
                    _ => result
                };
            return result;
        }

        // functions
        private static string ReverseCaesarion(string decrypt, ulong shift)
        {
            var decryptArray = decrypt.ToCharArray();

            decryptArray = decryptArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar - shift)).ToArray();

            return new string(decryptArray);
        }

        private static string ReverseCharAdder(string input, string passPhrase)
        {
            var inputArray = input.ToCharArray();

            foreach (var passChar in passPhrase)
            {
                for (var i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] = (char) (Convert.ToInt64(inputArray[i]) - Convert.ToInt64(passChar));
                }
            }

            return new string(inputArray);
        }

        private static string PreviousChar(string stringToPrevChar) // Removes one from the UTF-8 value
        {
            var prevCharArray = stringToPrevChar.ToCharArray();

            prevCharArray = prevCharArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar - 1)).ToArray();

            return prevCharArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
        }
    }
}
