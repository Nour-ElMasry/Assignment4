

using System.Text.RegularExpressions;

namespace Assignment4.Domain
{
    public class ChatBot
    {
        public string Name { get; set; }
        public string Description { get; set; }

        string _syntaxError = "Please follow given syntax";
        public void Intro() 
        {
            Console.WriteLine($"Hello! My name is {Name}.\n{Description}");
        }

        public int Greeting(string username) 
        {
            if (string.IsNullOrEmpty(username)) 
            {
                Console.WriteLine("String is Empty!!");
                return -1;
            }

            var fullName = username.Split(" ");
            if (fullName.Length > 2) {
                Console.WriteLine(_syntaxError);
                return -1;
            }

            var charCheck = new Regex(@"^[A-Za-z]+$");

            for (int i = 0; i < fullName.Length; i++)
            {
                if (!charCheck.IsMatch(fullName[i]))
                {
                    Console.WriteLine(_syntaxError);
                    return -1;
                }
            }

            Console.WriteLine($"Greetings {fullName[1]}! Happy to meet you!");
            return 0;
        }
    }
}