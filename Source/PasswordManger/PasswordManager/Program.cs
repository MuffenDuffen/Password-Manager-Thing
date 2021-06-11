using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var mPass = "testPassTestPassTttTas";

            var encryptionKey = Profile.GetEncryptionKey(mPass);
            var shift = Profile.GetShift(mPass);

            var sTring = "testPass";

            var encrypted = Encryptor.EncryptString(sTring, encryptionKey, shift);
            var decrypted = Decryptor.DecryptString(sTring, encryptionKey, shift);

            Console.WriteLine("{0}, {1}", encrypted, decrypted);
        }
    }
}