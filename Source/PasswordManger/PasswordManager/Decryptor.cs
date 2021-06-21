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

            credential.AppName = DecryptString(credential.AppName, key, shift, passPhrase);
            credential.Email = DecryptString(credential.Email, key, shift, passPhrase);
            credential.Password = DecryptString(credential.Password, key, shift, passPhrase);
            return credential;
        }

        public static string DecryptString(string decrypt, int[] key, ulong decryptShift, string passPhrase) //ToDo mek function us key but reverse
        {
            return key.Reverse()
                .Aggregate(decrypt, (current, i) => i switch
                {
                    0 => PreviousChar(current),
                    1 => Encryptor.InvertBits(current),
                    2 => LatinizeLol.ReverseConvertStringToLatinNumber(current),
                    3 => ReverseCaesarion(current, decryptShift),
                    4 => RomanNumberStuff.RomanNumeralCalculator.ReverseConvertToRomanNumeral(current),
                    5 => HexStuff.ReverseWordToHex(current),
                    6 => ReverseCharAdder(current, passPhrase),
                    7 => PythagoranTheorem.ReversePTheoremWWords(current),
                    8 => Encryptor.ReverseString(current),
                    9 => StringLolifierlol.ReverseLolifierlol(current),
                    10 => CircumferenceStuff.ReverseGetCircumferenceOfCharWithEntireText(current),
                    11 => BitReverserOfDoom.ReverseBitOrder(current),
                    _ => current
                });
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
                for (var i = 0; i < inputArray.Length; i++)
                    inputArray[i] = (char) (Convert.ToInt64(inputArray[i]) - Convert.ToInt64(passChar));

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
