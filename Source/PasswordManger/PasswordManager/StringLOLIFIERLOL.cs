using System.Linq;

namespace PasswordManger
{
    internal static class StringLolifierlol
    {
        internal static string Lolifierlol(string input)
        {
            for (var i = 0; i < input.Length; i++)
                if (i % 2 != 0)
                    input = input.Insert((i), 'L'.ToString());

            return input;
        }

        internal static string ReverseLolifierlol(string input)
        {
            var inputArray = input.ToCharArray();

            return inputArray.Where((t, i) => i % 2 == 0 || t != 'L').Aggregate("", (current, t) => current + t);
        }
    }
}
