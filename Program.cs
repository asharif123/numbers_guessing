namespace number_guessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Generate a random number between 1 to 100
            Random rng = new Random();
            //define random number constraints
            const int MINIMUM_RANDOM_NUMBER = 1;
            const int MAXIMUM_RANDOM_NUMBER = 101;
            int randomNumber = rng.Next(MINIMUM_RANDOM_NUMBER, MAXIMUM_RANDOM_NUMBER);
            //number of guesses that user has to guess the correct number
            const int MAX_NUM_OF_GUESSES = 4;
            const int NO_MORE_GUESSES_LEFT = 0;
            //max difference between random number and user guess to show if user is close
            const int MAX_DIFFERENCE = 5;

            //for loop to ask user to guess a number
            for (int GuessesLeft = MAX_NUM_OF_GUESSES; GuessesLeft >= NO_MORE_GUESSES_LEFT; GuessesLeft--)
            {
                Console.WriteLine($"\nGuess a number between {MINIMUM_RANDOM_NUMBER} to {MAXIMUM_RANDOM_NUMBER - 1}!\n");
                int userGuess = int.Parse(Console.ReadLine());

                //as soon as user enters value, immediately determine if it falls between 1 to 100 range
                if (userGuess < MINIMUM_RANDOM_NUMBER || userGuess > MAXIMUM_RANDOM_NUMBER - 1)
                {
                    Console.WriteLine($"\nPlease enter a value between {MINIMUM_RANDOM_NUMBER} to {MAXIMUM_RANDOM_NUMBER - 1}!");
                    continue; //use continue to restart for loop if user enters a value out of range
                }

                if (userGuess == randomNumber) //see if user enters the correct value
                {
                    Console.WriteLine("\nYou guessed correctly!");
                    break;
                }

                //calculate the absolute value of difference between randomNumber & userGuess
                int diffBetweenNumbers = Math.Abs(randomNumber - userGuess);

                //check if user's guess is off by 5
                //added at beginning to ensure user is aware that guess is off by 5
                //otherwise user will never know if he's close to guessing the correct number
                if (userGuess < randomNumber && diffBetweenNumbers <= MAX_DIFFERENCE)
                {
                    Console.WriteLine($"\nYour guess is too low but you are close! You have {GuessesLeft} guesses left!");
                }
                else if (userGuess < randomNumber)
                {
                    Console.WriteLine($"\nYour guess is too low! You have {GuessesLeft} guesses left!");
                }
                else if (userGuess > randomNumber && diffBetweenNumbers <= MAX_DIFFERENCE)
                {
                    Console.WriteLine($"\nYour guess is too high but you are close! You have {GuessesLeft} guesses left!");
                }
                else
                {
                    Console.WriteLine($"\nYou guess is too high! You have {GuessesLeft} guesses left!");
                }

                //Game ends if user fails to guess the number in 5 attempts.
                //and statement needed because if user enters correct number on last guess
                //it will show user was correct and not show user how many guesses are left
                //add game over statement at end to ensure user sees game over as the last message
                if (GuessesLeft == NO_MORE_GUESSES_LEFT && userGuess != randomNumber)
                {
                    Console.Write($"\nGame Over! The correct number is {randomNumber}!\n");
                }
            }
        }
    }
}