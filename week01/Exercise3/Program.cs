using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        string guess = "";
        int guess_number;
        int guesses = 0;
        bool flag = true;
        bool game = true;
        string again = "Y";

        while(game)
        {
            number = randomGenerator.Next(1, 100);
            Console.WriteLine($"What is the magic number? {number}");
        
            while(flag)
            {
                Console.Write("What is your guess? ");
                guess = Console.ReadLine();
                guess_number = int.Parse(guess);
                if (guess_number>number)
                {
                    Console.WriteLine($"Lower");
                    guesses += 1;
                }
                else if (guess_number<number)
                {
                    Console.WriteLine($"Higher");
                    guesses += 1;
                }
                else
                {
                    Console.WriteLine($"You guessed it!");
                    guesses += 1;
                    Console.WriteLine($"You took {guesses} guesses.");
                    flag = false;
                }
            }
            Console.Write($"Do you want to play again? Y/N: ");
            again = Console.ReadLine();
            if (again == "N")
            {
                game = false;
            }
            else
            {
                flag = true;
                guesses=0;
            }

        }
    }
}