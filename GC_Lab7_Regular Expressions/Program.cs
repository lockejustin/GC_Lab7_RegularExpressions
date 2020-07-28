using System;
using System.Text.RegularExpressions;

namespace GC_Lab7_Regular_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                //ValidateName(PromptForInput("Please enter a valid name: "));
                //ValidateEmail(PromptForInput("Please enter a valid email: "));
                //ValidatePhoneNumber(PromptForInput("Please enter a valid phone number (xxx-xxx-xxxx): "));
                //ValidateDate(PromptForInput("Please enter a valid date (mm/dd/yyyy): "));
                ValidateHTML(PromptForInput("Please enter a valid HTML tag: "));

                continueProgram = ContinueProgramYesNoPrompt("Would you like to go again?");
            }
            
        
        }

        public static string PromptForInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        public static void ValidateHTML(string code)
        {
            if (Regex.IsMatch(code, @"<([A-z][A-z0-9]*)\b[^>]*>(.*?)</\1>"))  //checks for valid HTML code 
                Console.WriteLine("This is a valid HTML tag!");
            else
                Console.WriteLine("This HTML tag is invalid!");
        }

        public static void ValidateDate(string date)
        {
            if (Regex.IsMatch(date, @"^[0-9]{2}[/][0-9]{2}[/][0-9]{4}$"))
                Console.WriteLine("This is a valid date entry!");
            else
                Console.WriteLine("This date entry is invalid!");
        }

        public static void ValidatePhoneNumber (string phoneNumber)
        {
            if (Regex.IsMatch(phoneNumber, @"^[0-9]{3}[-][0-9]{3}[-][0-9]{4}$")) //checks for proper phone number format xxx-xxx-xxxx
                Console.WriteLine("This is a valid phone number!");
            else
                Console.WriteLine("This phone number is invalid!");

        }

        public static void ValidateEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[0-z]{5,30}[@][0-z]{5,10}[.][0-z]{2,3}$")) //5-30 characters, @, 5-10 characters, ., 2-3 characters
                Console.WriteLine("This is a valid email!");
            else
                Console.WriteLine("This email is invalid!");

        }

        public static void ValidateName(string name)
        {
            if (Regex.IsMatch(name, @"\b[A-Z]{1}[A-z]{0,29}\b")) //checks that first letter is upper case, all characters are alpha, and there are less than 30 characters
                Console.WriteLine("This is a valid name!");
            else
                Console.WriteLine("This name is invalid!");
            
        }

        public static bool ContinueProgramYesNoPrompt(string message)  //prompts user if they'd like to continue and verifies proper entry
        {
            Console.Write($"{message} (y/n) ");
            string response = Console.ReadLine().ToLower();

            while (response != "y" && response != "n")  //checks to make sure the user enters either y or n
            {
                Console.Write("Your entry was invalid.  Please respond (y/n) ");
                response = Console.ReadLine().ToLower();
            }

            if (response == "y")
            {
                Console.WriteLine("\n");
                return true;
            }
            else
            {
                Console.WriteLine("\nThanks for using this program.  Goodbye!");
                return false;
            }
        }
    }

}
