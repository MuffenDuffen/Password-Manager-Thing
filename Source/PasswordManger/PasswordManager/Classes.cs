using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordManger
{
    internal sealed class Profile
    {
        internal string Name, MasterPassword;
        public ulong Shift;

        public int[] EncryptionKey;
        internal List<Credential> Credentials;

        internal static Profile GetFromFile(string path, int[] encryptionKey, ulong shift)
        {
            var profile = new Profile();

            var text = File.ReadAllLines(path);

            profile.Name = text[0];
            profile.MasterPassword = text[1];
            profile.EncryptionKey = encryptionKey;
            profile.Credentials = new List<Credential>();

            for (var i = 2; i < text.Length; i++)
            {
                profile.Credentials.Add(Decryptor.DecryptCredential(text[i], profile.EncryptionKey, shift));
            }

            return profile;
        }

        internal static void SaveToFile(Profile profile, string path, ulong shift)
        {
            var text = new List<string>
            {
                profile.Name,
                Encryptor.EncryptString(Interface.Hash(profile.MasterPassword), profile.EncryptionKey, shift)
            };
            text.AddRange(profile.Credentials.Select(credential => Encryptor.EncryptCredential(credential, profile.EncryptionKey, shift)));


            File.WriteAllLines(path, text);
        }

        internal static int[] GetEncryptionKey(string masterPassword)
        {
            var encryptionKey = new List<int>();

            var baseRand = new Random(masterPassword.Length);
            var rand0 = new Random(baseRand.Next() * masterPassword[0]);
            var rand1 = new Random(baseRand.Next() * masterPassword[1]);
            var rand2 = new Random(baseRand.Next() * masterPassword[2]);
            var rand3 = new Random(baseRand.Next() * masterPassword[3]);
            var rand4 = new Random(baseRand.Next() * masterPassword[^7]);
            var rand5 = new Random(baseRand.Next() * masterPassword[^7]);
            var rand6 = new Random(baseRand.Next() * masterPassword[^7]);
            var rand7 = new Random(baseRand.Next() * masterPassword[^7]);
            var rand8 = new Random(baseRand.Next() * masterPassword[^3]);
            var rand9 = new Random(baseRand.Next() * masterPassword[^2]);
            var rand10 = new Random(baseRand.Next() * masterPassword[^1]);
            var rand11 = new Random(baseRand.Next() * masterPassword[^1]);

            for (var i = 0; i < baseRand.Next(16, 32); i++)
            {
                switch (baseRand.Next(12))
                {
                    case 0:
                        encryptionKey.Add(rand0.Next(12));
                        break;
                    case 1:
                        encryptionKey.Add(rand1.Next(12));
                        break;
                    case 2:
                        encryptionKey.Add(rand2.Next(12));
                        break;
                    case 3:
                        encryptionKey.Add(rand3.Next(12));
                        break;
                    case 4:
                        encryptionKey.Add(rand4.Next(12));
                        break;
                    case 5:
                        encryptionKey.Add(rand5.Next(12));
                        break;
                    case 6:
                        encryptionKey.Add(rand6.Next(12));
                        break;
                    case 7:
                        encryptionKey.Add(rand7.Next(12));
                        break;
                    case 8:
                        encryptionKey.Add(rand8.Next(12));
                        break;
                    case 9:
                        encryptionKey.Add(rand9.Next(12));
                        break;
                    case 10:
                        encryptionKey.Add(rand10.Next(12));
                        break;
                    case 11:
                        encryptionKey.Add(rand11.Next(12));
                        break;
                }
            }

            var indexOfFirstTwo = 0;
            var indexOfSecondTwo = 0;

            for (var ii = 0; ii < encryptionKey.Count; ii++)
            {
                if (encryptionKey[ii] != 2) continue;

                indexOfFirstTwo = ii;
                break;
            }

            for (var iii = (indexOfFirstTwo + 1); iii < encryptionKey.Count; iii++)
            {
                if (encryptionKey[iii] != 2) continue;

                indexOfSecondTwo = iii;
                break;
            }

            for (var j = (indexOfSecondTwo + 1); j < encryptionKey.Count; j++)
            {
                if (encryptionKey[j] == 2) encryptionKey[j] = 0;
            }

            //foreach (int key in encryptionKey) Console.WriteLine(key);

            return encryptionKey.ToArray();
        }

        internal static ulong GetShift(string encrypt)
        {
            var randTest = new Random(encrypt.Length);

            return (ulong) randTest.Next(2, encrypt.Length);
        }
    }

    internal sealed class Credential
    {
        internal string AppName, Email, Password;

        internal Credential(string appName, string email, string password)
        {
            AppName = appName;
            Email = email;
            Password = password;
        }

        internal static Credential CreateCredential()
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement Because the line becomes too long
            if (!Interface.AskQuestion("Do you want to enter your own password? ").Contains("yes"))
                return new Credential(Interface.AskQuestion("Enter App name: "),
                    Interface.AskQuestion("Enter Email used: "), Interface.CreatePassword());

            Console.WriteLine("Enter a Password: ");
            var password = Console.ReadLine();

            return new Credential(Interface.AskQuestion("Enter App name: "), Interface.AskQuestion("Enter Email used: "), password);
        }

        public static void OutputCredentials(Credential credential)
        {
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("App Name: " + credential.AppName);
            Console.WriteLine("Email: " + credential.Email);
            Console.WriteLine("Password: " + credential.Password);

            Console.WriteLine("\n**************************************************************************");
        }
    }
}
