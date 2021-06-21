using System;
using System.Linq;

namespace PasswordManger
{
    internal static class HexStuff
    {
        internal static string WordToHex(string word)
        {
            var wordCharArray = word.ToCharArray();
            var finalString = wordCharArray.Aggregate(string.Empty, (current, c) => current + ((int) c).ToString("X") + ",");
            finalString = finalString[..^1];
            return finalString;
        }

        private static int ToIntFromHex(string s)
        {
            return Convert.ToInt16(s, 16);
        }

        internal static string ReverseWordToHex(string word)
        {
            var wordsArray = word.Split(',');
            return wordsArray.Aggregate("", (current, s) => current + (char) ToIntFromHex(s));
        }
    }
}
