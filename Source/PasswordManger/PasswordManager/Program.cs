using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var alpha = "abcdefghijklmnopqrstuvwxyz";

            foreach (char c in alpha)
            {
                foreach (char cc in alpha)
                {
                    foreach (char ccc in alpha)
                    {
                        Console.WriteLine(c.ToString() + cc.ToString() + ccc.ToString());
                    }
                }
            }
            //Interface.LogIn();
        }
    }
}