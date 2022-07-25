

using System.Text.RegularExpressions;

namespace Assignment4.Domain
{
    public class User
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public User(string name)
        {
           Name = name;
        }

        public override string ToString()
        {
            if(BirthDate == null)
                return $"\n       Username: {Name}\n      BirthDate: Not Provided";
            return $"       Username: {Name}\n      BirthDate: {DateOnly.FromDateTime((DateTime)BirthDate):dd/MM/yyyy}";
        }
    }
    public class ChatBot
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public User User { get; set; }

        string _syntaxError = "Please follow given syntax";

        public ChatBot(string name, string description)
        {
            Name = name;
            Description = description;
            User = new User("user");
        }

        public void instructions() {
            Console.WriteLine("List of commands: ");
            Console.WriteLine(" 1 - Enter your name\n 2 - Enter date of birth\n 3 - Get current date\n 4 - Get current time\n 5 - User info\n 6 - exit");
        }
        public void Intro() 
        {
            Console.WriteLine($"Hello! My name is {Name}.\n{Description}");
        }

        public void Msg(string msg) 
        {
            Console.WriteLine($"{ Name }: { msg }");
        }

        public string chat() {
            Console.Write($"{ User.Name }: ");
            return Console.ReadKey().KeyChar.ToString();
        }

        public int EnterUsername() 
        {
            if (User.Name != "user") {
                Msg("Name already introduced!");
                return -1;
            }

            Msg("Enter your full name:");
            var username = Console.ReadLine();

            if (string.IsNullOrEmpty(username)) 
            {
                Msg("String is Empty!!");
                return -1;
            }

            var fullName = username.Split(" ");
            if (fullName.Length > 2) {
                Msg(_syntaxError);
                return -1;
            }

            var charCheck = new Regex(@"^[A-Za-z]+$");

            for (int i = 0; i < fullName.Length; i++)
            {
                if (!charCheck.IsMatch(fullName[i]))
                {
                    Msg(_syntaxError);
                    return -1;
                }
            }

            User.Name = username;
            Msg($"Greetings {fullName[0]}! Happy to meet you!");
            return 0;
        }

        private bool IsDateTime(string d)
        {
            DateTime tempDate;
            if (DateTime.TryParse(d, out tempDate))
            {
                User.BirthDate = tempDate;
                return true;
            }
            return false;
        }

        public int EnterBirthDate() {
            if (User.BirthDate == null)
            {
                Msg("Birth date already introduced!");
                return -1;
            }

            Msg("Enter your birth date: (Syntax: yyyy/mm/dd)");
            var bd = Console.ReadLine();

            if (bd == null)
                return -1;
            
            if (IsDateTime(bd)) 
            {
                var userBd = User.BirthDate;
                if (DateTime.Now.Year - userBd.Value.Year < 0)
                    return -1;
                                
                Console.WriteLine($"You are {DateTime.Now.Year - userBd.Value.Year} years old!");
            }
            return 0;
        }

        public void GetDate() 
        {
            Msg($"Today's date is: {DateTime.Now:dd/MM/yyyy}");
        }

        public void GetTime()
        {
            Msg($"Current time is: {TimeOnly.FromDateTime(DateTime.Now)}");
        }

        public void UserInfo()
        {
            Msg(User.ToString());
        }
    }
}