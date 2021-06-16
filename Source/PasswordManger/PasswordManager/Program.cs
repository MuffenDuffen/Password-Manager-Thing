using System;
using System.Diagnostics;
using System.Linq;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();

            // var mPass = "HAHAIaSAKBAD2";
            // var passPhrase = "LoL" + Profile.GetPassPhrase(mPass);
            //
            // var encryptionKey = Profile.GetEncryptionKey(mPass);
            // foreach (var key in encryptionKey) Console.WriteLine(key);
            // var shift = Profile.GetShift(mPass);
            //
            // var cred = new Credential("testAppName", "testEmail", "testPass");
            //
            // var stopWatch = new Stopwatch();
            //
            // stopWatch.Start();
            // var eC = Encryptor.EncryptCredential(cred, encryptionKey, shift, passPhrase);
            // var dC = Decryptor.DecryptCredential(eC, encryptionKey, shift, passPhrase);
            // stopWatch.Stop();
            //
            // var ts = stopWatch.Elapsed;
            //
            // Console.WriteLine(eC);
            //
            // Console.WriteLine("---");
            //
            // Console.WriteLine(ts);
            // Console.WriteLine("---");
            // Console.WriteLine("LOL");
            // Console.WriteLine("------------------");
            //
            // Console.WriteLine(dC.AppName);
            // Console.WriteLine(dC.Email);
            // Console.WriteLine(dC.Password);

            string t = "HAHAIaSAKBAD2lOLImBest";

            var eS = BitReverserOfDoom.ReverseLol(t);
            var dS = BitReverserOfDoom.ReveseReverseLol(eS);

            Console.WriteLine(dS);
        }
    }
}