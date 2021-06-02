using System;
using System.Collections.Generic;
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

        private static string DecryptString(string decrypt, IEnumerable<int> key) //ToDo mek function us key but reverse
        {
            foreach (int keyAtIndex in key.Reverse())
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
                        break;
                    case 4:
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
            char[] prevCharArray = stringToPrevChar.ToCharArray();

            prevCharArray = prevCharArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar - 1)).ToArray();
                        
            return prevCharArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
        }
    }
}
