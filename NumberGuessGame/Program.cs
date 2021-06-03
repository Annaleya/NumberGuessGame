using System;

namespace NumberGuessGame
{
    class MainClass
    {
        public static void Main()
        {
            Random number = new Random();

            int winNumber = number.Next(0, 10);

            bool win = false;

            do
            {
                Console.WriteLine("Guess a number between 0 and 10: ");
                string s = Console.ReadLine();

                int i = int.Parse(s);

                if (i > winNumber)
                {
                    Console.WriteLine("To high, guess lower...");
                }
                else if (i < winNumber)
                {
                    Console.WriteLine("To low, guess higher...");
                }
                else if (i == winNumber)
                {
                    Console.WriteLine("You win!");
                    win = true;
                }
            } while (win == false);

            Console.WriteLine("Press space to restart");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            while (cki.Key != ConsoleKey.Escape)
            {
                if (cki.Key == ConsoleKey.Spacebar) Main();
                cki = Console.ReadKey(true);
            }
        }
    }
}
