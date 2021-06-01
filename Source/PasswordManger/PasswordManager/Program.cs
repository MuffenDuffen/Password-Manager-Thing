using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var encrypted = LatinizeLol.ConvertStringToLatinNumber("This is a test malteaxner3632gmail.com |><|");
            var decrypted = LatinizeLol.ReverseConvertStringToLatinNumber(encrypted);

            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);
            //Interface.LogIn();
        }
    }
}