using System;

namespace PasswordManger
{
    internal static class PythagoranTheorem
    {
        public static string PTheoremWWords(string encrypt)
        {
            var encryptArray = encrypt.ToCharArray();

            for (var i = 0; i < encryptArray.Length; i++) encryptArray[i] = (char) Math.Round(Math.Sqrt(Math.Pow(encryptArray[i], 2) * 2));

            return new string(encryptArray);
        }

        public static string ReversePTheoremWWords(string decrypt)
        {
            var decryptArray = decrypt.ToCharArray();

            for (var i = 0; i < decryptArray.Length; i++) decryptArray[i] = (char) Math.Round(Math.Sqrt(Math.Pow(decryptArray[i], 2) / 2));

            return new string(decryptArray);
        }
    }
}
