using System;
using System.Linq;

namespace PasswordManger
{
    internal static class Decryptor
    {
        public static Credential DecryptCredential(string credentialString, int[] key)
        {
            var credential = new Credential("", "", "");

            int firstComma = credentialString.IndexOf(',', 0);
            int secondComma = credentialString.IndexOf(',', firstComma + 1);

            string appNameLengthh = credentialString.Substring(0, firstComma);
            int appNameLength = Convert.ToInt16(credentialString.Substring(0, firstComma));

            string emailLengthh = credentialString.Substring(firstComma + 1, credentialString.IndexOf(',', firstComma));
            int emailLength = Convert.ToInt16(credentialString.Substring(firstComma + 1, firstComma));

            string passwordLengthh = credentialString.Substring(secondComma + 1, credentialString.IndexOf(',', secondComma - 2));
            int passwordLength = Convert.ToInt16(credentialString.Substring(secondComma + 1, credentialString.IndexOf(',', secondComma - 2)));

            string encrypted = credentialString[(credentialString.IndexOf(' ') + 1)..];
            
            credential.AppName = encrypted.Substring(0, appNameLength);
            credential.Email = encrypted.Substring(appNameLength, emailLength);
            credential.Password = encrypted.Substring(appNameLength + emailLength + 1, passwordLength - 1);


            credential.AppName = DecryptString(credential.AppName, key);
            credential.Email = DecryptString(credential.Email, key);
            credential.Password = DecryptString(credential.Password, key);

            return credential;
        }

        private static string DecryptString(string decrypt, int[] key)
        {
            string decrypted = Encryptor.InvertBits(decrypt);
            decrypted = PreviousChar(decrypted);
            return decrypted;
        }
        
        // functions
        private static string PreviousChar(string stringToPrevChar) // Removes one from the UTF-8 value
        {
            char[] stringToPrevCharArray = stringToPrevChar.ToCharArray();

            var indexInStringg = 0;
            
            foreach (char charFromUtf8ValueRemoveOne in stringToPrevCharArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar - 1)))
            {
                stringToPrevCharArray[indexInStringg] = charFromUtf8ValueRemoveOne;

                indexInStringg++;
            }

            return stringToPrevCharArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
        }
    }
}