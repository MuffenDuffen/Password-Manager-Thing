using System;
using System.Collections;
using System.Linq;
using System.Text;
using static System.Convert;

namespace PasswordManger
{
    internal static class Encryptor
    {
        public static Credential EncryptCredential(Credential credential, int[] key)
        {
            var encrypted = new Credential(EncryptString(credential.AppName, key), EncryptString(credential.Email, key),
                EncryptString(credential.Password, key));
            return encrypted;
        }

        private static string EncryptString(string encrypt, int[] key) //ToDo mek function us key
        {
            string encrypted = NextChar(encrypt);
            encrypted = InvertBits(encrypted);
            encrypted = InvertBits(encrypted);
            return encrypted;
        }
        //Gets next char and replaces old one

        //encryptions, replacecharwithnextchar, toandinvertbinary, tooctal

        private static string NextChar(string masterPassword) // adds one to the UTF-8 value
        {
            char[] masterArray = masterPassword.ToCharArray();
            for (var i = 0; i < masterPassword.Length; i++)
            {
                var utf8ValueFromChar = ToUInt64(masterArray[i]);
                var charFromUtf8ValueAddOne = (char) (utf8ValueFromChar + 1);
                masterArray[i] = charFromUtf8ValueAddOne;
            }

            return string.Concat(masterArray);
        }

        public static string InvertBits(string stringToInvert) // converts each characters UTF-8 value into bits and inverts it, then converts back to chars. China warning
        {
            
        }
}