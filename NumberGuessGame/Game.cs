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
        private int GenerateRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public bool PlayNextTurn()
         {
            //prompt user for guess
            Console.WriteLine($"Guess a number between {minNumber} and {maxNumber}:");
            var guess = int.Parse(Console.ReadLine());
            guessTotal++;

            //evaluate if the guess is correct
            if (IsWin(guess))
            {
                win = true;
                gameOver = true;
                Console.WriteLine("You win!");
            }
            //console response for incorrect guesses
            if (guess > random)
            {
                Console.WriteLine("Too high, guess lower...");
            }
            else if (guess < random)
            {
                Console.WriteLine("Too low, guess higher...");
                
            }
            //console response for too many guesses
           if (!win && IsPastMaxGuesses())
            {
                Console.WriteLine("Try Again! You have reached maximum number of guesses: " + maxTurns);
                gameOver = true;
            }
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
