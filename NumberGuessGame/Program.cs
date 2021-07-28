using System;
using System.Diagnostics;

namespace NumberGuessGame
{
    class Program
    {   //data for all games
        static int correctGuess = 0;
        static int guessTotal = 0;

        public static void Main()
        {
            Program program = new Program();
            program.Play();
        }
        //method for restarting the game
        private void Play()
        {
            Welcome();
            int levelMinNumber = 0;
            int levelMaxNumber = 10;
            int maxGuess = 3;

            while (true)
            {
                Game currentGame = new Game(levelMinNumber, levelMaxNumber, maxGuess);
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                //one game played here
                bool continuePlaying = true;

                while (continuePlaying)
                {
                    continuePlaying = currentGame.PlayNextTurn();
                }
                if (currentGame.win)
                {
                    correctGuess++;
                }
                guessTotal += currentGame.guessTotal;
                stopWatch.Stop();
                Console.WriteLine($"It took you {stopWatch.Elapsed.Seconds} seconds to complete this game");
                Score();

                Console.WriteLine("Would you like to restart? Yes or No");
                string respond = Console.ReadLine().ToLower();
                if (respond == "yes")
                {
                    //if user plays again, we want to make it harder
                    if (currentGame.win)
                    {
                        levelMaxNumber += levelMaxNumber;
                    }
                    continue;
                }
                //user did not want to play again
                break;
            }

            EndProgram();
        }

        //method to start the game
        private void Welcome()
        {
            Console.WriteLine("Welcome to the Random Number Game! To continue, Press enter...");
            Console.ReadLine();
        }
        //method for tracking score
        private void Score()
        {
            Console.WriteLine("Total Guesses: " + guessTotal);
            Console.WriteLine("Correct Guesses: " + correctGuess);
        }
        //method for closing program
        private void EndProgram()
        {
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
        }
    }   
}
