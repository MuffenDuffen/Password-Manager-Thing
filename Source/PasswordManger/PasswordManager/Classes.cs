using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordManger
{
    internal sealed class Profile
    {
        internal string Name, MasterPassword;

        public int[] EncryptionKey;
        internal List<Credential> Credentials;

        internal static Profile GetFromFile(string path, int[] encryptionKey)
        {
            var profile = new Profile();
            
            string[] text = File.ReadAllLines(path);

            profile.Name = text[0];
            profile.MasterPassword = text[1];
            profile.EncryptionKey = encryptionKey;
            profile.Credentials = new List<Credential>();

            for (var i = 2; i < text.Length; i++)
            {
                profile.Credentials.Add(Decryptor.DecryptCredential(text[i], profile.EncryptionKey));
            }
            
            return profile;
        }

        internal static void SaveToFile(Profile profile, string path)
        {
            var text = new List<string>
            {
                Encryptor.EncryptString(profile.Name, profile.EncryptionKey),
                Encryptor.EncryptString(Interface.Hash(profile.MasterPassword), profile.EncryptionKey)
            };
            text.AddRange(profile.Credentials.Select(credential => Encryptor.EncryptCredential(credential, profile.EncryptionKey)));


            File.WriteAllLines(path, text);
        }

        internal static int[] GetEncryptionKey(string masterPassword)
        {
            var encryptionKey = new List<int> ();
            
            var rand = new Random(masterPassword.Length);

            int length = rand.Next(16, 32);

            char randChar = masterPassword[rand.Next(masterPassword.Length)];

            int randInt = rand.Next(12);

            var random = new Random(length * randInt);

            int randomInt = random.Next(12);
            
            char randomChar = masterPassword[random.Next(masterPassword.Length)];

            for (var i = 0; i < length; i++)
            {
                switch (rand.Next(8))
                {
                    case 0: 
                        encryptionKey.Add(masterPassword.Length % 12);
                        break;
                    case 1: 
                        encryptionKey.Add(Convert.ToInt32(randChar) % 12);
                        break;
                    case 2: 
                        encryptionKey.Add(randInt);
                        break;
                    case 3:
                        encryptionKey.Add(randomInt);
                        break;
                    case 4: 
                        encryptionKey.Add(length % 12);
                        break;
                    case 5:
                        encryptionKey.Add(Convert.ToInt32(randomChar) % 12);
                        break;
                    case 6: 
                        encryptionKey.Add((randInt + Convert.ToInt32(randChar)) % 12);
                        break;
                    case 7: 
                        encryptionKey.Add((randomInt + Convert.ToInt32(randomChar)) % 12);
                        break;
                }
            }

            return encryptionKey.ToArray();
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
            string password = Console.ReadLine();
                
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
