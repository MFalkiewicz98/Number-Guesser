using System;

namespace Number_Guesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUpInfo();
            string userName = GetUserName();
            GreetUser(userName);

            Random random = new Random();

            int correctNumber = random.Next(1,11);
            bool correctAnswer = false;

            Console.WriteLine("Guess the drawn number between 1 and 10.");

            while (correctAnswer == false)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);

                if (!isNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Please enter a number.");
                    continue;
                }
                if(guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Please enter a number between 1 and 10.");
                    continue;
                }
                if(guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Wrong answer. The drawn number is greater.");
                }
                else if(guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Wrong answer. The drawn number is smaller.");
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage(ConsoleColor.Green, $"Congratulations {userName}! Answer is correct!");
                }
            }
        }

        static void GetUpInfo()
        {
            string appName = "Number Guesser";
            int appVersion = 1;
            string appAuthor = "MFalkiewicz98";

            string info = $"[{appName}] V: 0.0.{appVersion}, Founder: {appAuthor}";
            PrintColorMessage(ConsoleColor.Magenta, info);
        }

        static string GetUserName()
        {

            Console.WriteLine("What is your name?");
            string inputUserName = Console.ReadLine();
            return inputUserName;
        }

        static void GreetUser(string userName)
        {
            string greet = $"Good luck {userName}, guess the number...";
            PrintColorMessage(ConsoleColor.Blue, greet);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
