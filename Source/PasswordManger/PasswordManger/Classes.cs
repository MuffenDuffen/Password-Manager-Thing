using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordManger
{
    public class Profile
    {
        public string Name, MasterPassword;

        public int[] EncryptionKey;
        public List<Credential> Credentials;

        public static Profile GetFromFile(string path)
        {
            var profile = new Profile();
            
            string[] text = File.ReadAllLines(path);

            profile.Name = text[0];
            profile.MasterPassword = text[1];
            profile.EncryptionKey = GetEncryptionKey(profile.MasterPassword);
            profile.Credentials = new List<Credential>();

            return profile;
        }

        public static void SaveToFile(Profile profile, string path)
        {
            var text = new List<string>
            {
                [0] = Encryptor.EncryptString(profile.Name, profile.EncryptionKey),
                [1] = Encryptor.EncryptString(profile.MasterPassword, profile.EncryptionKey)
            };
            text.AddRange(profile.Credentials.Select(credential => Encryptor.EncryptCredential(credential, profile.EncryptionKey)));

            File.WriteAllLines(path, text);
        }

        public static int[] GetEncryptionKey(string masterPassword)
        {
            var rand = new Random(masterPassword.Length);
            
            var encryptionKey = new List<int>();

            encryptionKey.Add(masterPassword.Length);
            encryptionKey.Add(masterPassword[rand.Next(masterPassword.Length)]);
            return encryptionKey.ToArray();
        }
    }

    public sealed class Credential
    {
        public string AppName, Email, Password, UserName;

        private Credential(string appName, string email, string password, string userName)  {
            AppName = appName;
            Email = email;
            Password = password;
            UserName = userName;
        }

        public static Credential CreateCredential()
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