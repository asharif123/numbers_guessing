/*This game involves a secret number being chosen by the computer within a specific range (let’s say 1-100) 
 * //the player then tries to guess this number.

If the number they guess is too low, the program will say “too low” and if it is too high it will reply with “too high”. 
The player wins when they guess the correct number.

Added Difficulty: Put a limit on how many wrong guesses they can have. Too many and the game ends with “You lose”.

rocket Tips: First thing to look at is generating a random number. Despite the language you choose, most of the time a random number can be created using a random generator function or object.
.NET has the “Random” object and C++ has rand().
Once you have a random number chosen, ask the player for a guess.
Compare their guess to this random number chosen. An easy if statement can be used to see if it is too high or too low. If they are equal, tell the player they win and restart the game.
*/
namespace number_guessing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Generate a random number between 1 to 100
            Random rng = new Random();
            int randomNumber = rng.Next(1, 101);
            //for loop to ask user to guess a number
            for (int GuessesLeft = 4; GuessesLeft >= 0; GuessesLeft--)
            {
                Console.WriteLine("Guess a number between 1 to 100!\n");
                int userGuess = int.Parse(Console.ReadLine());
                //Game ends if user fails to guess the number in 5 attempts.
                //and statement needed because if user enters correct number on last guess
                //it will show user was correct and not show user how many guesses are left
                if (GuessesLeft == 0 && userGuess != randomNumber)
                {
                    Console.Write($"\nGame Over! The correct number is {randomNumber}!\n");
                }
                //see if user enters a number btwn 1 to 100
                if (userGuess == randomNumber) //see if user enters the correct value
                {
                    Console.WriteLine("\nYou guessed correctly!");
                    break;
                }
                else if (userGuess < 1 || userGuess > 100)
                {
                    Console.WriteLine("\nPlease enter a value between 1 to 100!");
                    return;
                }
                else if (userGuess < randomNumber)
                {
                    Console.WriteLine($"\nYour guess is too low! You have {GuessesLeft} guesses left!");
                }
                else
                {
                    Console.WriteLine($"\nYou guess is too high! You have {GuessesLeft} guesses left!");
                }
            }
        }
    }
}