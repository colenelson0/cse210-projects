class Bread : WarmItem
{
    // Attributes
    private int _quantity;
    private string _seasoning;

    // Constructors
    public Bread()
    {
        // For user input
        SetCategory("Bread");
    }
    public Bread(bool qOption, string seasoning)
    {
        // For the starting order list
        SetCategory("Bread");
        if (qOption)
        {
            _quantity = 12;
        }
        else
        {
            _quantity = 6;
        }
        _seasoning = seasoning;
    }

    // Methods
    public override void CalculateBakeTime()
    {
        SetBakeTime(_quantity/2);
    }
    public override string GetStringForMenu()
    {
        string strForMenu = "Bread, ";
        strForMenu += $"{_quantity}pc, {CapitalizeWord(_seasoning)}";
        return strForMenu;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
    public override void CalculatePrice()
    {
        if (_quantity == 6)
        {
            SetPrice(500);
        }
        else
        {
            SetPrice(900);
        }
    }
    public override void Compose()
    {
        // get the seasoning options from a file
        List<string> options = new();
        string sideFile = "sides.txt";
        if (File.Exists(sideFile)) { 
            string[] strings = File.ReadAllLines(sideFile);
            string[] breadList = strings[0].Split(',');
            foreach (string breadSeasoning in breadList)
            {
                options.Add(breadSeasoning);
            }
        }
        int optionCount = options.Count;

        Console.Write("Quantity:\n1: 6 pieces\n2: 12 pieces\n\n");

        int option;
        Console.Write("SELECT: ");
        while (!int.TryParse(Reader.ReadLine(), out option))
        {
            Console.Write("Invalid input\nSELECT: ");
        }
        if (option == 1)
        {
            _quantity = 6;
        }
        else
        {
            _quantity = 12;
        }

        Console.Write("\nSeasonings:\n");
        for (int h = 0; h < optionCount; h++)
        {
            Console.WriteLine($"{h+1}: {options[h]}");
        }
        Console.Write("\nSELECT: ");
        bool inRange;
        do
        {
            while (!int.TryParse(Reader.ReadLine(), out option))
            {
                Console.Write("Invalid input\nSELECT: ");
            }
            inRange = option > 0 && (option-1) < optionCount;
            if (!inRange)
            {
                Console.Write("Invalid input\nSELECT: ");
            }
        } while (!inRange);
        _seasoning = options[option-1];
        Console.Write("\n");

        SetPhase("uncooked");
        CalculateBakeTime();
    }
}