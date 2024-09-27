using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new();
        int numSmallest = 9999999;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        string inputString;
        int input;
        do
        {
            Console.Write("Enter number: ");
            inputString = Console.ReadLine();
            input = int.Parse(inputString);

            if (input != 0)
            {
                numberList.Add(input);
                if (input > 0 && input < numSmallest)
                {
                    numSmallest = input;
                }
            }
        } while (input != 0);

        int numSum = numberList.Sum();
        double numAverage = numberList.Average();
        int numLargest = numberList.Max();
        numberList.Sort();

        Console.WriteLine($"The sum is: {numSum}");
        Console.WriteLine($"The average is: {numAverage}");
        Console.WriteLine($"The largest number is: {numLargest}");
        Console.WriteLine($"The smallest positive number is: {numSmallest}");
        Console.WriteLine("The sorted list is:");
        foreach (int num in numberList)
        {
            Console.WriteLine(num);
        }
    }
}