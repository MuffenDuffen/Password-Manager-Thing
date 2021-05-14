using System;

namespace PasswordManger
{
    public static class Interface
    {
        public static void LogIn()
        {
            Console.WriteLine("PasswordManger Program by Nanojaw studios");
            string input = AskQuestion("Master Password: ");
            
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
            Console.WriteLine("Type Done to exit, type Help for more information");
            string input = AskQuestion("What would you like to do? ");
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
            
            return answer;
        }
    }
}