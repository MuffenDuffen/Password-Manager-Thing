using System;

namespace PasswordManger
{
    public class PythagoranTheorem
    {
        public static string pTheoremWWords(string encrypt)
        {
            var encryptArray = encrypt.ToCharArray();

            for (int i = 0; i < encryptArray.Length; i++)
            {
                encryptArray[i] = (char) Math.Sqrt(Math.Pow(encryptArray[i], 2) * 2);
            }

            return new string(encryptArray);
        }

        public static string ReversepTheoremWWords(string decrypt)
        {
            var decryptArray = decrypt.ToCharArray();

            for (int i = 0; i < decryptArray.Length; i++)
            {
                decryptArray[i] = (char) Math.Sqrt(Math.Pow(decryptArray[i], 2) / 2);
            }
            
            return new string(decryptArray);
        }
    }
}
