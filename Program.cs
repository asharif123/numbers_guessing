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
            //variables to define number of guesses left use to define game over code outside for loop
            int guessesLeft;

            //for loop to ask user to guess a number
            for (guessesLeft = MAX_NUM_OF_GUESSES; guessesLeft >= NO_MORE_GUESSES_LEFT; guessesLeft--)
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

                //if statement to see if user enters a number less than or greater than randomNumber
                if (userGuess < randomNumber)
                {
                    Console.WriteLine("\nGuess is too low!");
                }
                else
                {
                    Console.WriteLine("\nGuess is too high!");
                }

                //separate if statement to determine if user's guess is no more than 5 off from randomNumber
                if (diffBetweenNumbers <= MAX_DIFFERENCE)
                {
                    Console.WriteLine("\nYou are close!");
                }

                //append number of guesses that user has left based on above if conditions
                Console.WriteLine($"\nYou have {guessesLeft} guesses left!");

                //Game ends if user fails to guess the number in 5 attempts.
                //and statement needed because if user enters correct number on last guess
                //it will show user was correct and not show user how many guesses are left
                //add game over statement at end to ensure user sees game over as the last message
                if (guessesLeft == NO_MORE_GUESSES_LEFT && userGuess != randomNumber)
                {
                    Console.Write($"\nGame Over! The correct number is {randomNumber}!\n");
                }
            }
        }
    }
}