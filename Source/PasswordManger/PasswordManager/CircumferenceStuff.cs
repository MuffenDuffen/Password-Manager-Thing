using System;

namespace PasswordManger
{
    internal static class CircumferenceStuff
    {
        public static string GetCircumferenceOfCharWithEntireText(string text)
        {
            var charArray = text.ToCharArray();

            for (var i = 0; i < charArray.Length; i++)
            {
                charArray[i] = GetCircumferenceOfChar(charArray[i]);
            }

            return new string(charArray);
        }

        public static string ReverseGetCircumferenceOfCharWithEntireText(string text)
        {
            var charArray = text.ToCharArray();

            for (var i = 0; i < charArray.Length; i++)
            {
                charArray[i] = ReverseGetCircumferenceOfChar(charArray[i]);
            }

            return new string(charArray);
        }

        private static char GetCircumferenceOfChar(char c)
        {
            var charValue = (int) c;

            var circumferenceOfChar = Math.Round(charValue * Math.PI);

            return (char) circumferenceOfChar;
        }

        private static char ReverseGetCircumferenceOfChar(char c)
        {
            var charValue = (int) c;
            var circumferenceOfChar = Math.Round(charValue / Math.PI);

            return (char) circumferenceOfChar;
        }
    }
}
