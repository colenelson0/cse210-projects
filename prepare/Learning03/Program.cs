using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new();
        Fraction f2 = new(9);
        Fraction f3 = new(7,9);
        Fraction f4 = new();

        f2.SetBottom(3);
        f3.SetTop(8);
        f4.SetTop(7);
        f4.SetBottom(8);
        Console.WriteLine($"Fraction 1: {f1.GetFractionString()} or {f1.GetDecimalValue()}");
        Console.WriteLine($"Fraction 2: {f2.GetFractionString()} or {f2.GetDecimalValue()}");
        Console.WriteLine($"Fraction 3: {f3.GetFractionString()} or {f3.GetDecimalValue()}");
        Console.WriteLine($"Fraction 4: {f4.GetFractionString()} or {f4.GetDecimalValue()}");
    }
}