using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        Console.WriteLine("Welcome to the Guess My Number game!");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();
            guess = int.Parse(input);

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed it!");
            }

        }                    
    }
}