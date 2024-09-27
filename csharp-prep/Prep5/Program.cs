using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        // 1st function
        DisplayWelcome();
        // 2nd function
        string name = PromptUserName();
        // 3rd function
        int num = PromptUserNumber();
        // 4th function
        int square = SquareNumber(num);
        // 5th function
        DisplayResult(name, square);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string numInput = Console.ReadLine();
        return int.Parse(numInput);
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string username, int squareNum)
    {
        Console.WriteLine($"{username}, the square of your number is {squareNum}");
    }
}