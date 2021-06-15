using System;
using System.Linq;

namespace PasswordManger
{
    internal static class HexStuff
    {
        internal static string wordToHex(string word)
        {
            var wordCharArray = word.ToCharArray();
            var finalString = wordCharArray.Aggregate(String.Empty, (current, c) => current + ((int) c).ToString("X") + ",");
            finalString = finalString[..^1];
            return finalString;
        }

        internal static string reverseWordToHex(string word)
        {
            var wordsArray = word.Split(','); 
            return wordsArray.Aggregate("", (current, wordLOL) => current + (char) int.Parse(wordLOL, System.Globalization.NumberStyles.HexNumber));
        }
    }
}
