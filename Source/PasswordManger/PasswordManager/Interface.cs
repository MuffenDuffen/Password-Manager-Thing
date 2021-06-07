﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace PasswordManger
{
    internal static class Interface
    {
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.String")]
        public static void LogIn()
        {
            Console.WriteLine("PasswordManager Program by Nanojaw studios");
            string path = Directory.GetCurrentDirectory() + @"\data.txt";
            if (File.Exists(path))
            {
                var tries = 0;
                while (tries != 64) //ToDo add a timer
                {
                    Console.Write("Enter Master Password: ");
                    string input = Console.ReadLine();

                    // return a hashed value that we compare to the stored masterPassword
                    string hashedInput = Hash(input);

                    int[] encryptionKey = Profile.GetEncryptionKey(input);

                    ulong shift = Profile.GetShift(input);

                    string encryptedInput = Encryptor.EncryptString(hashedInput, encryptionKey, shift);

                    // Get heavily encrypted master password from a file
                    string[] lines = File.ReadAllLines(path);
                    string masterPassword = lines[1];

                    if (encryptedInput == masterPassword)
                    {
                        Console.WriteLine("\nYou are successfully logged in!");
                        GetCredentials(encryptionKey, path, input, shift);
                    }
                    else
                    {
                        Console.WriteLine("Wrong password, you have {0} tries left", 64 - tries);
                        tries++;
                        if (tries == 64) File.Delete(path); // Delete the file containing passwords if you fail too many times, then create a new profile
                    }
                }
            }
            else
            {
                CreateProfile(path);
            }
        }

        private static void CreateProfile(string path)
        {
            Console.WriteLine("Welcome to the password manager, please make a profile to start using this app!");
            Console.Write("Enter a secure Master password: ");
            string masterPassword = Console.ReadLine();

            string name = AskQuestion("What is your name: ");

            Console.WriteLine("To get started, you need to add some credentials");

            ulong shiftt = Profile.GetShift(masterPassword);

            var profile = new Profile {MasterPassword = masterPassword, Credentials = new List<Credential>() {Credential.CreateCredential()}, Name = name, EncryptionKey = Profile.GetEncryptionKey(masterPassword), Shift = shiftt};

            var done = false;
            while (!done)
            {
                string input = AskQuestion("Do you want to add more credentials: ");
                switch (input)
                {
                    case "yes":
                        profile.Credentials.Add(Credential.CreateCredential());
                        break;
                    case "no":
                        done = true;
                        break;
                }
            }

            Profile.SaveToFile(profile, path, profile.Shift);

            GetCredentials(profile.EncryptionKey, path, masterPassword, profile.Shift);
        }

        private static void GetCredentials(int[] encryptionKey, string path, string masterPassword, ulong shift)
        {
            Console.WriteLine("Type 'exit' to exit, type 'help' for more information");

            var profile = Profile.GetFromFile(path, encryptionKey, shift);
            profile.MasterPassword = masterPassword;
            profile.Shift = shift;

            var done = false;

            while (!done)
            {
                string input = AskQuestion("What would you like to do? ");

                switch (input)
                {
                    // Direct Actions
                    case "exit":
                        Profile.SaveToFile(profile, path, profile.Shift);
                        done = true;
                        break;
                    case "help":
                        Console.WriteLine("**********************************");
                        Console.WriteLine("Help menu");
                        Console.WriteLine("");
                        Console.WriteLine("Type 'exit' to exit");
                        Console.WriteLine("To find login credentials, write 'get login'");
                        Console.WriteLine("To create login credentials, write 'create login'");
                        Console.WriteLine("To list all credentials, write 'list logins'");
                        Console.WriteLine("To clear console, write 'clear'");
                        Console.WriteLine("**********************************");
                        break;

                    case "clear":
                        Console.Clear();
                        Console.WriteLine("Type 'exit' to exit, type 'help' for more information");
                        break;

                    case "list logins":
                        foreach (var cred in profile.Credentials) OutputCredentials(cred);
                        break;

                    case "get login":
                        input = AskQuestion("What do you want to search with? ");
                        switch (input)
                        {
                            case "index":
                                var index = Convert.ToInt32(AskQuestion("Enter index: "));
                                var credential = profile.Credentials[index];
                                Credential.OutputCredentials(credential);
                                break;

                            case "email":
                                string email = AskQuestion("Enter email: ");
                                foreach (var t in profile.Credentials.Where(t => t.Email == email))
                                {
                                    Credential.OutputCredentials(t);
                                }

                                break;

                            case "app name":
                                string appName = AskQuestion("Enter app name: ");
                                foreach (var tt in profile.Credentials.Where(tt => tt.AppName == appName))
                                {
                                    Credential.OutputCredentials(tt);
                                }

                                break;
                        }

                        break;
                    case "create login":
                        profile.Credentials.Add(Credential.CreateCredential());
                        break;
                }
            }

            Console.WriteLine("Successfully logged out.");
            Environment.Exit(0);
        }

        #region Non-Interface functions

        public static string AskQuestion(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();

            while (string.IsNullOrEmpty(answer))
            {
                Console.Write(question);
                answer = Console.ReadLine();
            }

            return answer.ToLower();
        }

        private static void OutputCredentials(Credential credential)
        {
            Console.WriteLine("Login information:");
            Console.WriteLine("App name: " + credential.AppName);
            Console.WriteLine("Email used: " + credential.Email);
            Console.WriteLine("Password used: " + credential.Password);
            Console.WriteLine("");
        }

        public static string Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            // Triple hashing because why not
            var sha256 = new SHA256Managed();
            var sha384 = new SHA384Managed();
            var sha512 = new SHA512Managed();

            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash256 = sha256.ComputeHash(textBytes);
            byte[] hash384 = sha384.ComputeHash(hash256);
            byte[] hash512 = sha512.ComputeHash(hash384);

            return BitConverter.ToString(hash512);
        }

        public static string CreatePassword()
        {
            var rng = new RNGCryptoServiceProvider();
            var rand = new Random();
            var password = new byte[rand.Next(16, 64)];
            rng.GetBytes(password);
            return System.Text.Encoding.UTF8.GetString(password);
        }

        #endregion
    }
}
