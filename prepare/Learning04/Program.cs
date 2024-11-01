using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new("Samuel Bennett", "Multiplication");
        string assignmentText = assignment1.GetSummary();
        Console.WriteLine(assignmentText);

        MathAssignment assignment2 = new("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        assignmentText = assignment2.GetSummary();
        Console.WriteLine(assignmentText);
        assignmentText = assignment2.GetHomeworkList();
        Console.WriteLine(assignmentText);

        WritingAssignment assignment3 = new("Mary Waters", "European History", "The Causes of World War II");
        assignmentText = assignment3.GetSummary();
        Console.WriteLine(assignmentText);
        assignmentText = assignment3.GetHomeworkList();
        Console.WriteLine(assignmentText);
    }
}