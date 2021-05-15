using System;
using System.IO;

namespace PasswordManger
{
    public static class Interface
    {
        public static void LogIn()
        {
            Console.WriteLine("PasswordManger Program by Nanojaw studios");
            Console.Write("Enter Master password: ");
            string input = Console.ReadLine();
            // Implement Maltes encryptor
            
            // return a hashed value that we compare to the masterPassword
            
            // Get heavily encrypted master password from a file
            const string masterPassword = "PASSWORD";
            
           
            if (input == masterPassword)
            {
                GetPasswords();
            }
        }

        private static void GetPasswords()
        {
            Console.WriteLine("\nYou are successfully logged in!");
            Console.WriteLine("Type 'done' to exit, type 'help' for more information");
            Console.WriteLine(File.Exists(@"F:\Reps\Password-Manager-Thing\Source\PasswordManger\PasswordManger\data.txt")); 
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

            while (answer == null)
            {
                Console.Write(question);
                answer = Console.ReadLine();
            }
            
            return answer.ToLower();
        }
    }
}