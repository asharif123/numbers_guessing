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
            const int maxNumOfGuesses = 4;
            const int noMoreGuessesLeft = 0;
            //for loop to ask user to guess a number
            for (int GuessesLeft = maxNumOfGuesses; GuessesLeft >= noMoreGuessesLeft; GuessesLeft--)
            {
                Console.WriteLine("\nGuess a number between 1 to 100!\n");
                int userGuess = int.Parse(Console.ReadLine());
                //Game ends if user fails to guess the number in 5 attempts.
                //and statement needed because if user enters correct number on last guess
                //it will show user was correct and not show user how many guesses are left
                if (GuessesLeft == noMoreGuessesLeft && userGuess != randomNumber)
                {
                    Console.Write($"\nGame Over! The correct number is {randomNumber}!\n");
                }
                if (userGuess == randomNumber) //see if user enters the correct value
                {
                    Console.WriteLine("\nYou guessed correctly!");
                    break;
                }
                //create separate if-else statements for when user enters a number from 1 to 100
                if (userGuess < MINIMUM_RANDOM_NUMBER || userGuess > MAXIMUM_RANDOM_NUMBER - 1)
                {
                    Console.WriteLine("\nPlease enter a value between 1 to 100!");
                    return;
                }
                //check if user's guess is off by 5
                //added at beginning to ensure user is aware that guess is off by 5
                //otherwise user will never know if he's close to guessing the correct number
                else if (userGuess < randomNumber && (Math.Abs(randomNumber - userGuess) <= 5))
                {
                    Console.WriteLine($"\nYour guess is too low but you are close! You have {GuessesLeft} guesses left!");
                }
                else if (userGuess < randomNumber)
                {
                    Console.WriteLine($"\nYour guess is too low! You have {GuessesLeft} guesses left!");
                }
                else if (userGuess > randomNumber && (Math.Abs(randomNumber - userGuess) <= 5))
                {
                    Console.WriteLine($"\nYour guess is too high but you are close! You have {GuessesLeft} guesses left!");
                }
                else
                {
                    Console.WriteLine($"\nYou guess is too high! You have {GuessesLeft} guesses left!");
                }
            }
        }
    }
}