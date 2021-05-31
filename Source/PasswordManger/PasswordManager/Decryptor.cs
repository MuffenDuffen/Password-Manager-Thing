using System;
using System.Linq;

namespace PasswordManger
{
    internal class Decryptor
    {
        public static Credential DecryptCredential(string credentialString, int[] key)
        {
            var credential = new Credential("", "", "");

            int firstComma = credentialString.IndexOf(',', 0);
            int secondComma = credentialString.IndexOf(',', firstComma + 1);

            int appNameLength = Convert.ToInt16(credentialString[..firstComma]);

            int emailLength = Convert.ToInt16(credentialString.Substring(firstComma + 1, secondComma - firstComma - 1));

            int passwordLength = Convert.ToInt16(credentialString.Substring(secondComma + 1, credentialString.IndexOf(' ') - secondComma - 1));

            string encrypted = credentialString[(credentialString.IndexOf(' ') + 1)..];
            
            credential.AppName = encrypted[..appNameLength];
            credential.Email = encrypted.Substring(appNameLength, emailLength);

            credential.Password = encrypted.Substring(appNameLength + emailLength, passwordLength);


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
            char[] prevCharArray = stringToPrevChar.ToCharArray();

            prevCharArray = prevCharArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar - 1)).ToArray();
                        
            return prevCharArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
        }
    }
}