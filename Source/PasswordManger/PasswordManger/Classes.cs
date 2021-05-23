using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordManger
{
    public class Profile
    {
        public string Name, MasterPassword, EncryptionKey;

        public IEnumerable<Credential> Credentials;

        public Profile GetFromFile(string path)
        {
            var profile = new Profile();
            
            string[] text = File.ReadAllLines(path);

            profile.Name = text[0];
            profile.MasterPassword = text[1];
            profile.EncryptionKey = GetEncryptionKey(profile.MasterPassword);
            profile.Credentials = new List<Credential>();

            return profile;
        }

        private static string GetEncryptionKey(string masterPassword)
        {
            var rand = new Random(masterPassword.Length);
            
            string encryptionKey = masterPassword.Length + ",";
            encryptionKey += masterPassword[rand.Next(masterPassword.Length)] + ",";
            return encryptionKey;
        }
    }
    public class Credential
    {
        public string AppName, Email, Password ; 

        public Credential(string appName, string email, string password)
        {
            AppName = appName;
            Email = email;
            Password = password;
        }
    }
}