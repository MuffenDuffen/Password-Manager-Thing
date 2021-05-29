using System;

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
            string decrypted = Encryptor.InvertBits(decrypt);
            decrypted = PreviousChar(decrypted);
            return decrypted;
        }
        
        // functions
        private static string PreviousChar(string masterPassword) // Removes one to the UTF-8 value
        {
            foreach (char c in masterPassword)
            {
                var utf8ValueFromChar = Convert.ToUInt64(c);

                var charFromUtf8ValueAddOne = (char) (utf8ValueFromChar - 1);

                masterPassword = masterPassword.Replace(c, charFromUtf8ValueAddOne);
            }

            return masterPassword;
        }
    }
}