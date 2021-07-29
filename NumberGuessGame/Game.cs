using System;
namespace NumberGuessGame
{
    public class Game
    {
        private int minNumber;
        private int maxNumber;
        private int maxTurns;
        public int guessTotal { get; private set; } = 0;

        public bool gameOver { get; private set; } = false;
        public bool win { get; private set; } = false;

        //value the computer selects randomly
        private int random { get; }

        public Game(int minNumber, int maxNumber, int maxTurns)
        {
            this.minNumber = minNumber;
            this.maxNumber = maxNumber;
            this.maxTurns = maxTurns;

            this.random = GenerateRandom(minNumber, maxNumber);
        }
        //generate random number
        private int GenerateRandom(int min, int max)
        {
            Logger.WriteToLog("Random Number generated");
            Random random = new Random();
            return random.Next(min, max);
        }

        public bool PlayNextTurn()
         {
            //prompt user for guess
            Logger.WriteToLog("Starting new turn");
            Console.WriteLine($"Guess a number between {minNumber} and {maxNumber}:");
            var guess = int.Parse(Console.ReadLine());
            guessTotal++;

            //evaluate if the guess is correct
            if (IsWin(guess))
            {
                Logger.WriteToLog("Game won");
                win = true;
                gameOver = true;
                Console.WriteLine("You win!");
            }
            //console response for incorrect guesses
            if (guess > random)
            {
                Logger.WriteToLog("Guessed too high");
                Console.WriteLine("Too high, guess lower...");
            }
            else if (guess < random)
            {
                Logger.WriteToLog("Guessed too low");
                Console.WriteLine("Too low, guess higher...");
                
            }
            //console response for too many guesses
           if (!win && IsPastMaxGuesses())
            {
                Logger.WriteToLog("Game lost");
                Console.WriteLine("Try Again! You have reached maximum number of guesses: " + maxTurns);
                gameOver = true;
            }

            return !gameOver;
         }

        //checks to see if guess is correct or not
        public bool IsWin(int guess) {
            return guess == random;
        }
        //checks to see if guessed too many times
        public bool IsPastMaxGuesses() {
            return guessTotal >= maxTurns;
        }
       
    }
}
