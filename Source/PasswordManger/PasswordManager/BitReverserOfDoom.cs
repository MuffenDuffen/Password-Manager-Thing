using System;

namespace PasswordManger
{
    internal static class BitReverserOfDoom
    {
        public static string ReverseBitOrder(string encrypt)
        {
            var encrypted = "";
            foreach (var c in encrypt)
            {
                var binary = Convert.ToString(c, 2);
                while (binary.Length < 16) binary = binary.Insert(0, "0");

                binary = Encryptor.ReverseString(binary);
                encrypted += (char) Convert.ToInt32(binary, 2);
            }

            return encrypted;
        }
    }
}
