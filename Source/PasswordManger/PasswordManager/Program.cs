using System;

namespace PasswordManger
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var mPass = "testPassTestPassTttT";

            var encryptionKey = Profile.GetEncryptionKey(mPass);
            var shift = Profile.GetShift(mPass);

            var sTring = "testPass";

            var encrypted = Encryptor.EncryptString(sTring, encryptionKey, shift);
            var decrypted = Decryptor.DecryptString(encrypted, encryptionKey, shift);

            Console.WriteLine("{0}, {1}", encrypted, decrypted);
        }
    }
}