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
            Console.WriteLine("Guess a number 1 to 100!\n");
            int userGuess = int.Parse(Console.ReadLine());

            //see if user enters a number btwn 1 to 100
            if (userGuess < 1 || userGuess > 100)
            {
                Console.WriteLine("\nPlease enter a value between 1 to 100!");
                return;
            }

            //Generate a random number between 1 to 100
            Random rng = new Random();
            int randomNumber = rng.Next(1, 100);
            Console.WriteLine(randomNumber);
            if (userGuess < randomNumber)
            {
                Console.WriteLine("Your guess is too low! Try again!");
            }
            else if (userGuess > randomNumber)
            {
                Console.WriteLine("You guess is too high!");
            }
            else
            {
                Console.WriteLine("You guessed correctly!");
            }
        }
    }
}