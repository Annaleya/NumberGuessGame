using System;

namespace NumberGuessGame
{
    class Program
    {
        int correctGuess = 0;

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
                int winNumber = random(levelMinNumber, levelMaxNumber);

                //one game played here

                bool continuePlaying = true;
                int guessTotal = 0;

                while (continuePlaying)
                {
                    int guess = userData();
                    guessTotal++;
                    continuePlaying = CheckInput(guess, guessTotal, winNumber, maxGuess);
                }

                Console.WriteLine("Would you like to restart? Yes or No");
                string respond = Console.ReadLine().ToLower();
                if (respond == "yes")
                {
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
        //prompt user for guess
        private int userData()
        {
            Console.WriteLine("Guess a number between 0 and 10:");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        ///  Checks the guess and tells user if they won, lost or guessed incorrectly
        /// </summary
        /// <param name="guess"></param>
        /// <returns>True if game is continuing</returns>
        private bool CheckInput(int guess, int totalGuesses, int winNumber, int maxGuess)
        {
            bool continueGame = true;
            //method for correct guess
            if (guess == winNumber)
            {
                correctGuess++;
                Console.WriteLine("You win!");
                Console.WriteLine("Total Guesses:" + totalGuesses);
                Console.WriteLine("Correct Guesses: " + correctGuess);
                continueGame = false;
            }

            //method for incorrect guess(to high)
            if (guess > winNumber)
            {
                Console.WriteLine("To high, guess lower...");
            }
            //method for incorrect guess(to low)
            else if (guess < winNumber)
            {
                Console.WriteLine("To low, guess higher...");
            }
            //limit number of total guesses
            if (continueGame && totalGuesses >= maxGuess)
            {
                Console.WriteLine("Try Again! You have reached maximum number of guesses: " + maxGuess);
                Score(totalGuesses, correctGuess);
                continueGame = false;
            }

            return continueGame;
        }

        private void Level()
        {

        }
        //method for tracking score
        private void Score(int totalGuesses, int correctGuesses)
        {
            Console.WriteLine("Total Guesses: " + totalGuesses);
            Console.WriteLine("Correct Guesses: " + correctGuesses);
        }
        //method for closing program
        private void EndProgram()
        {
            Console.WriteLine("/n");
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
        }
        //method for random number generator
        private int random(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }   
}
