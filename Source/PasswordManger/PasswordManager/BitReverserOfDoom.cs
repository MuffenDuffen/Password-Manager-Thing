using System;

namespace PasswordManger
{
    public class BitReverserOfDoom
    {
        public static char reverseBitsForChar(char c)
        {
            var charNumberInBinary = Convert.ToString(c, 2);
            var charNumberInBinaryArray = charNumberInBinary.ToCharArray();
            
            Array.Reverse(charNumberInBinaryArray);
            var charNumberInBinaryReversed = new string(charNumberInBinaryArray);

            return (char) Convert.ToInt32(charNumberInBinaryReversed, 2);
        }
    }
}
