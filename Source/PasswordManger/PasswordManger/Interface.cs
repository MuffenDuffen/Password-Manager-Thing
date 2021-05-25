using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace PasswordManger
{
    public static class Interface
    {
        public static void LogIn()
        {
            Console.WriteLine("PasswordManger Program by Nanojaw studios");
            string path = Directory.GetCurrentDirectory() + @"\data.txt";
            if (File.Exists(path))
            {
                var tries = 0;
                while (tries != 64) //ToDo add a timer 
                {
                    string input = AskQuestion("Enter Master password: ");
                    // return a hashed value that we compare to the stored masterPassword
                    string hashedInput = Hash(input);
            
                    // Get heavily encrypted master password from a file
                    string[] lines = File.ReadAllLines(path);
                    string masterPassword = lines[1];
                    
                    if (hashedInput == masterPassword )
                    {
                        Console.WriteLine("\nYou are successfully logged in!");
                        GetCredentials(path);
                    }
                    
                    Console.WriteLine("Wrong password, you have {0} tries left", 64 - tries);
                    tries++;    
                }
                
                File.Delete(path); // Delete the file containing passwords if you fail too many times, then create a new profile
            }
            CreateProfile(path); 
        }

        private static void CreateProfile(string path)
        {
            Console.WriteLine("Welcome to the password manager, please make a profile to start using this app!");
            string masterPassword = AskQuestion("Enter a secure Master password: ");

            string name = AskQuestion("What is your name: ");

            File.WriteAllText(path, name + "\n" + Hash(masterPassword));
            
            Console.WriteLine("To get started, you need to add some credentials");
            
            var profile = new Profile {MasterPassword = masterPassword, Credentials = new List<Credential>() {CreateCredential()}, Name = name};
            
            var done = false;
            while (!done)
            {
                string input = AskQuestion("Do you want to add more credentials: ");
                switch (input)
                {
                    case "yes":
                        profile.Credentials.Add(CreateCredential());
                        break;
                    case "no":
                        done = true;
                        break;
                }
            }
            GetCredentials(path);
        }

        private static Credential CreateCredential()
        {
            return new(AskQuestion("Enter App name: "), AskQuestion("Enter Email used: "), CreatePassword());
        }

        private static void GetCredentials(string path)
        {
            
            Console.WriteLine("Type 'exit' to exit, type 'help' for more information");
            
            var profile = new Profile();
            
            var done = false;

            while (!done)
            {
                string input = AskQuestion("What would you like to do? ");
                
                switch (input)
                {
                    // Direct Actions
                    case "exit":
                        done = true;
                        break;
                    case "help":
                        Console.WriteLine("**********************************");
                        Console.WriteLine("Help menu");
                        Console.WriteLine("");
                        Console.WriteLine("Type 'exit' to exit");
                        Console.WriteLine("To find login credentials, write 'get login'");
                        Console.WriteLine("To create login credentials, write 'create login'");
                        Console.WriteLine("**********************************");
                        break;
                    case "test":
                        CreateCredential();
                        break;
                    
                    case "get login":
                        input = AskQuestion("What do you want to search with?");
                        switch (input)
                        {
                            case "index":
                                string index = AskQuestion("Enter index: ");
                                string[] lines = File.ReadAllLines(path);
                                
                                break;
                            case "email":
                                string email = AskQuestion("Enter email: ");
                                break;
                            case "app name":
                                string appName = AskQuestion("Enter app name: ");
                                break;
                            case "password":
                                string password = AskQuestion("Enter password: ");
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine("Successfully logged out.");
            Environment.Exit(0);
        }

        private static string AskQuestion(string question)
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

        private static string Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            // Double hashing because why not
            var sha256 = new SHA256Managed();
            var sha512 = new SHA512Managed();
            
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash256 = sha256.ComputeHash(textBytes);
            byte[] hash512 = sha512.ComputeHash(hash256);

            return BitConverter.ToString(hash512);
        }
        private static string CreatePassword()
        {
            var rng = new RNGCryptoServiceProvider();
            var rand = new Random();
            var password = new byte[rand.Next(16, 64)];
            rng.GetBytes(password);
            return System.Text.Encoding.UTF8.GetString(password);
        }
    }
}