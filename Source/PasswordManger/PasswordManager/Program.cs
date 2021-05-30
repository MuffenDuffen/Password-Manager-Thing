using System;
using Kolibri;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Clippy.PushStringToClipboard("��v'z$*�����ΐhoƞki���|:").OK);
            Interface.LogIn();
        }
    }
}