namespace CashRegister;

class Program
{
    static void Main(string[] args)
    {
        Bin myBin = new("quarters", 40, (float)0.25);
        myBin.ModifyAmount(6);
        Console.WriteLine(myBin.TotalValue());
    }
}
