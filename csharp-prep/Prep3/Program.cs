using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain;
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            string input;
            int guess;
            int guessCount = 0;
            do
            {
                Console.Write("What is your guess? ");
                input = Console.ReadLine();
                guess = int.Parse(input);

                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

                guessCount++;
            } while (guess != magicNumber);

            Console.WriteLine($"Total guesses: {guessCount}");

            Console.Write("Play again? ");
            input = Console.ReadLine();
            playAgain = input == "yes";
        } while (playAgain);
    }
}