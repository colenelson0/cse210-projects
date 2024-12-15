class Wings : WarmItem
{
    // Attributes
    private int _quantity;
    private string _sauce;

    // Constructors
    public Wings()
    {
        // For user input
        SetCategory("Wings");
    }
    public Wings(bool qOption, string sauce)
    {
        // For user input
        SetCategory("Wings");
        if (qOption)
        {
            _quantity = 16;
        }
        else
        {
            _quantity = 8;
        }
        _sauce = sauce;
    }

    // Methods
    public override void CalculateBakeTime()
    {
        SetBakeTime((_quantity/2)+1);
    }
    public override string GetStringForMenu()
    {
        string strForMenu = "Wings, ";
        strForMenu += $"{_quantity}pc, {CapitalizeWord(_sauce)}";
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
            SetPrice(700);
        }
        else
        {
            SetPrice(1200);
        }
    }
    public override void Compose()
    {
        // get the sauce options from a file
        List<string> options = new();
        string sideFile = "sides.txt";
        if (File.Exists(sideFile)) { 
            string[] strings = File.ReadAllLines(sideFile);
            string[] wingsList = strings[1].Split(',');
            foreach (string wingSauce in wingsList)
            {
                options.Add(wingSauce);
            }
        }
        int optionCount = options.Count;

        Console.Write("Quantity:\n1: 8 pieces\n2: 16 pieces\n\n");

        Console.Write("SELECT: ");
        int option;
        while (!int.TryParse(Reader.ReadLine(), out option))
        {
            Console.Write("Invalid input\nSELECT: ");
        }
        if (option == 1)
        {
            _quantity = 8;
        }
        else
        {
            _quantity = 16;
        }

        Console.Write("\nSauces:\n");
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
        _sauce = options[option-1];
        Console.Write("\n");

        SetPhase("uncooked");
        CalculateBakeTime();
    }
}