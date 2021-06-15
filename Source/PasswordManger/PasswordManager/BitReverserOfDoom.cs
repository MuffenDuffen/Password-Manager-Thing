using System;

namespace PasswordManger
{
    public class BitReverserOfDoom
    {
        public static string reverseBitOrder(string encrypt)
        {
            var encrypted = "";
            foreach (char c in encrypt)
            {
                var binary = Convert.ToString(c, 2);
                while (binary.Length <= 16) { binary = binary.Insert(0, 0);}
                encrypted += Encryptor.reverseString(binary);
            }
            return encrypted;
        }
    }
}
