using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string user_name = PromptUserName();
        int favorite_number = PromptUserNumber();
        int square_number = SquareNumber(favorite_number);
        DisplayResult(user_name,square_number);

    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string username = Console.ReadLine();
        return username;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string fav_number_str = Console.ReadLine();
        int fav_number = int.Parse(fav_number_str);
        return fav_number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}