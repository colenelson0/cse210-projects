using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList;
        numberList = new(); // creates the list during run time

        int input = -1;
        while (input != 0)
        {
            Console.Write("Enter something: ");
            string inputString = Console.ReadLine();
            input = int.Parse(inputString);
            if (input != 0)
            {
                numberList.Add(input);
            }
        }

        foreach (int item in numberList)
        {
            Console.WriteLine(item);
        }
    }
}