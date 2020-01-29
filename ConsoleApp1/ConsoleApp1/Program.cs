using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo(); // Run our function to initiate app info
            
            GetUserName(); // Get user's name

            GameLoop(); // Run game loop
        }

        static void GetAppInfo() 
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Jade Doucet";

            // Change text color
            Console.ForegroundColor = ConsoleColor.Green;

            // App intro
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            Console.ResetColor();
        }

        static void GetUserName() {
            // Get User Input
            Console.Write("Please enter your name: ");

            string inputName = Console.ReadLine();

            Console.WriteLine("Hello {0}, let's play a game...", inputName);
        }

            // Inform user of invaid input
        static void InvalidInput() {
            PrintColorMessage(ConsoleColor.Blue, "That's not a number...");
        }

        static void GameEnd() {
            PrintColorMessage(ConsoleColor.Yellow, "Congrats, you win!.. for now");
            // Ask to play again
            Console.WriteLine("Play Again? [Y or N]");
        }

        static void PrintColorMessage(ConsoleColor color, string message) {

            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
        static void GameLoop() {
            while (true)
            {
                // Create Random object and correct number
                Random random = new Random();
                int correctNum = random.Next(1, 10);

                // Init guess variable
                int guess = 0;
                Console.WriteLine("Guess a number between 1 and 10");

                // While guess is not correct
                while (guess != correctNum)
                {
                    // Get user input
                    string input = Console.ReadLine();

                    // Ensure input is a number
                    if (!int.TryParse(input, out guess))
                    {
                        // Inform user of incorrect input
                        InvalidInput();

                        // Tell loop to keep going
                        continue;
                    };

                    // Cast input guess to int
                    guess = Int32.Parse(input);

                    // Check guess
                    if (guess != correctNum)
                    {
                        // Change color to red
                        Console.ForegroundColor = ConsoleColor.Red;
                        // Respond to user
                        Console.WriteLine("Nope, try again");
                        // Change color back to white
                        Console.ResetColor();
                    }
                }
                // End and Ask if user wants to play again
                GameEnd();

                // Get Answer
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    continue;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
