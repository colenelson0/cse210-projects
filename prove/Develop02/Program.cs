using System;

class Program
{
    static void Main(string[] args)
    {
        Journal _journal = new();
        int selection;
        do
        {
            ShowMenu();
            Console.Write("What would you like to do? ");
            selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                _journal.AddEntry();
            }
            if (selection == 2)
            {
                _journal.DisplayEntries();
            }
            if (selection == 3)
            {
                _journal.LoadFile();
            }
            if (selection == 4)
            {
                _journal.SaveToFile();

                // Exceeding requirements. The user can set an author for the journal when saving to a file. The author will be properly displayed when "Display" is selected in the main menu.
            }
        } while (selection != 5);
    }

    static void ShowMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
    }
}