using System;

namespace NumberGuessGame
{
    class Program
    {
        int winNumber;
        int guess;
        int numberOfGuess = 0;
        int maxGuess = 3;
        int guessTotal = 0;
        int correctGuess = 0;

        public static void Main()
        {
            Program program = new Program();
            program.Welcome();
            program.random();

            while (true)
            {
                program.userData();
                program.Game();
            }
        }

        //method to start the game
        private void Welcome()
        {
            Console.WriteLine("Welcome to the Random Number Game! To continue, Press enter...");
            Console.ReadLine();
        }
        //prompt user for guess
        private void userData()
        {
            Console.WriteLine("Guess a number between 0 and 10:");
            guess = int.Parse(Console.ReadLine());
        }
        //method for displaying correct or incorrect answers
        private void Game()
        {
            //limit number of total guesses
            if (numberOfGuess > maxGuess -2)
            { 
                Console.WriteLine("Try Again! You have reached maximum number of guesses: " + maxGuess);
                PlayAgain();
            }
            //method for correct guess
            else if (guess == winNumber)
            {
                correctGuess++;
                guessTotal++;
                numberOfGuess++;
                Console.WriteLine("You win!");
                Console.WriteLine("Total Guesses:" + guessTotal);
                Console.WriteLine("Correct Guesses: " + correctGuess);
                PlayAgain();
            }
            //method for incorrect guess(to high)
            else if (guess > winNumber)
            {
                guessTotal++;
                numberOfGuess++;
                Console.WriteLine("To high, guess lower...");
            }
            //method for incorrect guess(to low)
            else if (guess < winNumber)
            {
                guessTotal++;
                numberOfGuess++;
                Console.WriteLine("To low, guess higher...");
            }
        }
        //method for tracking score
        private void Score()
        {
            Console.WriteLine("Total Guesses: " + guessTotal);
            Console.WriteLine("Correct Guesses: " + correctGuess);
        }
        //method for restarting the game
        private void PlayAgain()
        {
            Console.WriteLine("Would you like to restart? Yes or No");
            string respond = Console.ReadLine().ToLower();
            if (respond == "yes")
            {
                Welcome();
                random();
                while (true)
                {
                    userData();
                    Game();
                }
            }
            else if (respond == "no")
            {
                EndProgram();
            }
            else
            {
                Console.WriteLine("Your response wasn't recognized...");
                Console.WriteLine("Game is now closing");
                EndProgram();
            }
        }
        //method for closing program
        private void EndProgram()
        {
            Console.WriteLine("/n");
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
        }
        //method for random number generator
        private void random()
        {
            Random random = new Random();
            winNumber = random.Next(0, 10);
        }
    }   
}
