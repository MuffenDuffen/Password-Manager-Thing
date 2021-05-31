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

        internal static Profile GetFromFile(string path)
        {
            var profile = new Profile();
            
            string[] text = File.ReadAllLines(path);

            profile.Name = text[0];
            profile.MasterPassword = text[1];
            profile.EncryptionKey = GetEncryptionKey(profile.MasterPassword);
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
            var rand = new Random(masterPassword.Length);

            var encryptionKey = new List<int> {rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5), rand.Next(1, 5)};

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