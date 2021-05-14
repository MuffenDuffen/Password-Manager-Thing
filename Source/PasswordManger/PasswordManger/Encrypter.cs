using System;

namespace PasswordManger
{
    internal static class Encryptor
    {
        //Gets next char and replaces old one
        
        //encryptions, replacecharwithnextchar, toandinvertbinary, tooctal
        
        internal static string addOneToUTF8value(string masterPassword)
        {
            ulong utf8ValueFromChar;
            char charFromUtf8ValueAddOne;

            foreach (char c in masterPassword)
            {
                utf8ValueFromChar = Convert.ToUInt64(c);

                charFromUtf8ValueAddOne = (char) (utf8ValueFromChar + 1);

                masterPassword = masterPassword.Replace(c, charFromUtf8ValueAddOne);
            }

            return masterPassword;
        }

        internal static string toBinaryAndInvertBits(string stringToInvert)
        {
            string invertedStringFromBinary = "";
            ulong utf8ValueFromChar1;
            string utf8ValueFromChar1InBinary;
            int indexInString = 0;

            foreach (char c in stringToInvert)
            {
                utf8ValueFromChar1 = Convert.ToUInt64(c);

                utf8ValueFromChar1InBinary = Convert.ToString((int) utf8ValueFromChar1, 2);

                foreach (char cc in utf8ValueFromChar1InBinary)
                {
                    if (cc == '1')
                    {
                        utf8ValueFromChar1InBinary = utf8ValueFromChar1InBinary.Insert(indexInString '0');
                    }
                    else if (cc == '0')
                    {
                        utf8ValueFromChar1InBinary = utf8ValueFromChar1InBinary.Replace(cc, '1');
                    }
                }
            }

            return invertedStringFromBinary;
        }
    }
}