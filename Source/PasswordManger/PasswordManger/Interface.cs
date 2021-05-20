﻿using System;
using System.IO;
using System.Text.Encodings;
using System.Security.Cryptography;

namespace PasswordManger
{
    public static class Interface
    {
        public static void LogIn()
        {
            Console.WriteLine("PasswordManger Program by Nanojaw studios");
            if (File.Exists(@"F:\Reps\Password-Manager-Thing\Source\PasswordManger\PasswordManger\data.txt"))
            {
                Console.Write("Enter Master password: ");
                string input = Console.ReadLine();
                // return a hashed value that we compare to the masterPassword
                string hashedInput = Hash(input);
            
                // Get heavily encrypted master password from a file
                string[] lines = File.ReadAllLines(@"F:\Reps\Password-Manager-Thing\Source\PasswordManger\PasswordManger\data.txt");
                string masterPassword = lines[0];
            
           
                if (hashedInput == masterPassword)
                {
                    GetCredentials();
                }
            }
            CreateProfile();
        }

        private static void CreateProfile()
        {
            //ToDo Make the function create a file in which it stores the master password and the other passwords
            Console.WriteLine("Welcome to the password manager, please make a profile to start using this app!");
            string masterPassword = AskQuestion("Enter a secure Master password: ");
        }

        private static void GetCredentials()
        {
            Console.WriteLine("\nYou are successfully logged in!");
            Console.WriteLine("Type 'done' to exit, type 'help' for more information");
            
            var done = false;

            while (!done)
            {
                string input = AskQuestion("What would you like to do? ");
                
                switch (input)
                {
                    // Direct Actions
                    case "done":
                        done = true;
                        break;
                    case "help":
                        Console.WriteLine("**********************************");
                        Console.WriteLine("Help menu");
                        Console.WriteLine("");
                        Console.WriteLine("Type 'done' to exit");
                        Console.WriteLine("To find login credentials, write 'get login'");
                        Console.WriteLine("To create login credentials, write 'create login'");
                        Console.WriteLine("**********************************");
                        break;
                    case "get login":
                        input = AskQuestion("What do you want to search with?");
                        switch (input)
                        {
                            case "index":
                                string index = AskQuestion("Enter index: ");
                                File.ReadAllLines(Path.GetFullPath("Data.txt"));
                                
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

            var sha256 = new SHA256Managed();
            var sha512 = new SHA512Managed();
            
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash256 = sha256.ComputeHash(textBytes);
            byte[] hash512 = sha512.ComputeHash(hash256);

            return BitConverter.ToString(hash512);
        }
    }
}