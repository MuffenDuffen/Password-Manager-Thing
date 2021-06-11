using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Interface.LogIn();

            var mPass = "testPassTestPassTttT";

            var sTring = "testPass";

            var encryptionKey = Profile.GetEncryptionKey(mPass);
            var shift = Profile.GetShift(mPass);

            var encrypted = Encryptor.EncryptString(sTring, encryptionKey, shift);
            var decrypted = Decryptor.DecryptString(encrypted, encryptionKey, shift);

            Console.WriteLine("{0}, {1}", encrypted, decrypted);
        }
    }
}