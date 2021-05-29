using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordManger
{
    public sealed class Profile
    {
        internal string Name, MasterPassword;

        internal int[] EncryptionKey;
        internal List<Credential> Credentials;

        internal static Profile GetFromFile(string path)
        {
            var profile = new Profile();
            
            string[] text = File.ReadAllLines(path);

            profile.Name = text[0];
            profile.MasterPassword = text[1];
            profile.EncryptionKey = GetEncryptionKey(profile.MasterPassword);
            profile.Credentials = new List<Credential>();

            return profile;
        }

        internal static void SaveToFile(Profile profile, string path)
        {
            var text = new List<string>
            {
                [0] = Encryptor.EncryptString(profile.Name, profile.EncryptionKey),
                [1] = Encryptor.EncryptString(profile.MasterPassword, profile.EncryptionKey)
            };
            text.AddRange(profile.Credentials.Select(credential => Encryptor.EncryptCredential(credential, profile.EncryptionKey)));

            File.WriteAllLines(path, text);
        }

        internal static int[] GetEncryptionKey(string masterPassword)
        {
            var rand = new Random(masterPassword.Length);

            var encryptionKey = new List<int> {masterPassword.Length, masterPassword[rand.Next(masterPassword.Length)]};

            return encryptionKey.ToArray();
        }
    }

    public sealed class Credential
    {
        internal string AppName, Email, Password;
        internal readonly string UserName;

        private Credential(string appName, string email, string password, string userName)  {
            AppName = appName;
            Email = email;
            Password = password;
            UserName = userName;
        }

        internal static Credential CreateCredential()
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement Because the line becomes too long
            if (Interface.AskQuestion("Do you want to enter your own password? ").Contains("yes"))
            {
                return new Credential(Interface.AskQuestion("Enter App name: "), Interface.AskQuestion("Enter Email used: "), Interface.AskQuestion("Enter Password: "), Interface.AskQuestion("Enter Username used: "));
            }

            return new Credential(Interface.AskQuestion("Enter App name: "), Interface.AskQuestion("Enter Email used: "), Interface.CreatePassword(), Interface.AskQuestion("Enter Username used: "));
        }
    }
}