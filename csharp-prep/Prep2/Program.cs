using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePer = int.Parse(Console.ReadLine());

        string letter;
        if (gradePer >= 90)
        {
            letter = "A";
        }
        else if (gradePer >= 80)
        {
            letter = "B";
        }
        else if (gradePer >= 70)
        {
            letter = "C";
        }
        else if (gradePer >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string gradeSign;
        if (gradePer % 10 >= 7 && gradePer >= 60 && gradePer < 90)
        {
            gradeSign = "+";
        }
        else if (gradePer % 10 < 3 && gradePer >= 60 && gradePer < 100)
        {
            gradeSign = "-";
        }
        else
        {
            gradeSign = "";
        }

        string gradeWithSign;
        gradeWithSign = letter + gradeSign;
        Console.WriteLine($"Letter grade: {gradeWithSign}");
        
        if (letter == "A" || letter == "B" || letter == "C")
        {
            Console.WriteLine("\nYou passed the class. Congratulations!");
        }
        else
        {
            Console.WriteLine("\nYou did not pass the class. Don't give up!");
        }
    }
}