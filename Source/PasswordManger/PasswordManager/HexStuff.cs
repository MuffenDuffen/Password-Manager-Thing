namespace PasswordManger
{
    internal static class HexStuff
    {
        internal static string wordToHex(string word)
        {
            var wordCharArray = word.ToCharArray();
            var finalString = string.Empty;
            foreach (var c in wordCharArray) finalString = finalString + ((int) c).ToString("X") + ",";
            finalString = finalString[..^1];
            return finalString;
        }

        internal static string reverseWordToHex(string word)
        {
            var wordsArray = word.Split(',');
            var result = "";
            foreach (var s in wordsArray) result = result + (char) int.Parse(s, System.Globalization.NumberStyles.HexNumber);
            return result;
        }
    }
}
