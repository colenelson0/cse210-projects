class Soda : Item
{
    // Attributes
    private string _sodaBase;
    private List<string> _flavors;

    // Constructors
    public Soda()
    {
        // For user input
        SetCategory("Soda");
        _flavors = new();
    }
    public Soda(string sodaBase, List<string> sodaFlavors)
    {
        // For the starting order list
        SetCategory("Soda");
        _sodaBase = sodaBase;
        _flavors = sodaFlavors;
    }

    // Methods
    public override string GetStringForMenu()
    {
        string strForMenu = CapitalizeWord(_sodaBase);

        if (_flavors.Count > 0)
        {
            string[] flPrint = _flavors.ToArray();
            Array.Sort(flPrint);
            foreach (string flavor in flPrint)
            {
                strForMenu += $", {CapitalizeWord(flavor)}";
            }
        }
        return strForMenu;
    }
    public int GetFlavorNum()
    {
        return _flavors.Count;
    }
    public void AddFlavor(string flavor)
    {
        // For the starting order list
        _flavors.Add(flavor);
    }
    public override void CalculatePrice()
    {
        int flavNum = _flavors.Count;
        SetPrice(200 + (50 * flavNum));
    }
    public override void Compose()
    {
        // get the soda base and flavor options from a file
        List<string> optionsA = new();
        List<string> optionsB = new();
        string sideFile = "sides.txt";
        if (File.Exists(sideFile)) { 
            string[] strings = File.ReadAllLines(sideFile);
            string[] sodaList = strings[2].Split(',');
            foreach (string sodaBase in sodaList)
            {
                optionsA.Add(sodaBase);
            }
            string[] flavorList = strings[3].Split(',');
            foreach (string sodaFlavor in flavorList)
            {
                optionsB.Add(sodaFlavor);
            }
        }
        int optionCountA = optionsA.Count;
        int optionCountB = optionsB.Count;

        Console.Write("Sodas:\n");
        for (int h = 0; h < optionCountA; h++)
        {
            Console.WriteLine($"{h+1}: {optionsA[h]}");
        }
        Console.Write("\nSELECT: ");
        int option;
        bool inRange;
        do
        {
            while (!int.TryParse(Reader.ReadLine(), out option))
            {
                Console.Write("Invalid input\nSELECT: ");
            }
            inRange = option > 0 && (option-1) < optionCountA;
            if (!inRange)
            {
                Console.Write("Invalid input\nSELECT: ");
            }
        } while (!inRange);
        _sodaBase = optionsA[option-1];

        Console.Write("\nFlavors:\n");
        for (int g = 0; g < optionCountB; g++)
        {
            Console.WriteLine($"{g+1}: {optionsB[g]}");
        }
        Console.Write("\n");

        do
        {
            Console.Write("ADD FLAVOR [0: DONE]: ");
            do
            {
                while (!int.TryParse(Reader.ReadLine(), out option))
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
                inRange = option > -1 && (option-1) < optionCountB;
                if (!inRange)
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
            } while (!inRange);
            if (option > 0)
            {
                string flavor = optionsB[option-1];
                AddFlavor(flavor);
                Console.WriteLine($"Added {flavor}");
            }
        } while (option > 0);
        Console.Write("\n");

        SetPhase("ready");
    }
}