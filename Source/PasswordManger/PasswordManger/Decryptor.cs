using System;
using System.Linq;

namespace PasswordManger
{
    internal static class Decryptor
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
            string decrypted = Encryptor.InvertBits(decrypt);
            decrypted = PreviousChar(decrypted);
            return decrypted;
        }
        
        // functions
        internal static string PreviousChar(string stringToPrevChar) // Removes one from the UTF-8 value
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