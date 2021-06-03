﻿using System;

namespace NumberGuessGame
{
    class MainClass
    {
        public static void Main()
        {
            Random number = new Random();

            int winNumber = number.Next(0, 10);
            int numberOfGuess = 0;
            int maxGuess = 3;
            int winTotal = 0;
            int roundTotal = 0;
            bool win = false;



                do
                {
                    Console.WriteLine("Guess a number between 0 and 10: ");
                    string s = Console.ReadLine();

                    int i = int.Parse(s);

                if (numberOfGuess > maxGuess-2)
                {
                    roundTotal++;
                    Console.WriteLine("You have reached maximum number of guesses: " + maxGuess);
                    break;
                }

                else if (i > winNumber)
                    {
                        numberOfGuess++;
                        Console.WriteLine("To high, guess lower...");
                    }
                    else if (i < winNumber)
                    {
                        numberOfGuess++;
                        Console.WriteLine("To low, guess higher...");
                    }
                    else if (i == winNumber)
                    {
                        roundTotal++;
                        winTotal++;
                        Console.WriteLine("You win!");
                        win = true;
                    }
                } while (win == false);

            Console.WriteLine("Total wins: " + winTotal);
            Console.WriteLine("Total plays: " + roundTotal);

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
