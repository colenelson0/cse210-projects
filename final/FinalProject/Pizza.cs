class Pizza : WarmItem
{
    // Attributes
    private string _pizzaType;
    private List<string> _toppings;

    // Constructors
    public Pizza()
    {
        // For user input
        SetCategory("Pizza");
        _toppings = new();
    }
    public Pizza(PizzaType pizzaType)
    {
        // For the starting order list
        SetCategory("Pizza");
        _pizzaType = pizzaType.GetTypeName();
        _toppings = pizzaType.GetToppings();
    }

    // Methods
    public override void CalculateBakeTime()
    {
        int toppingNum = _toppings.Count;
        SetBakeTime(10+toppingNum);
    }
    public override string GetStringForMenu()
    {
        string strForMenu = "Pizza";
        if (_toppings.Count < 1)
        {
            strForMenu += ", Cheese";
        }
        else
        {
            // Organize the list
            string[] topPrint = _toppings.ToArray();
            Array.Sort(topPrint);
            foreach (string topping in topPrint)
            {
                strForMenu += $", {CapitalizeWord(topping)}";
            }
        }
        return strForMenu;
    }
    public int GetToppingNum()
    {
        return _toppings.Count;
    }
    public void AddTopping(string topping)
    {
        _toppings.Add(topping);
    }
    public override void CalculatePrice()
    {
        int topNum = _toppings.Count;
        SetPrice(1100 + (100 * topNum));
    }
    public override void Compose()
    {
        // A default pizza type will be assigned for simplicity
        _pizzaType = "User";

        // get the topping options from a file
        List<string> options = new();
        string pizzaToppingFile = "pizza_toppings.txt";
        if (File.Exists(pizzaToppingFile)) { 
            string[] strings = File.ReadAllLines(pizzaToppingFile);

            foreach (string str in strings)
            {
                options.Add(str);
            }
        }
        int optionCount = options.Count;

        Console.WriteLine("Toppings:");
        for (int h = 0; h < optionCount; h++)
        {
            Console.WriteLine($"{h+1}: {options[h]}");
        }
        Console.Write("\n");

        int option;
        do
        {
            Console.Write("ADD TOPPING [0: DONE]: ");
            bool inRange;
            do
            {
                while (!int.TryParse(Reader.ReadLine(), out option))
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
                inRange = option > -1 && (option-1) < optionCount;
                if (!inRange)
                {
                    Console.Write("Invalid input\nSELECT: ");
                }
            } while (!inRange);
            if (option > 0)
            {
                string topping = options[option-1];
                AddTopping(topping);
                Console.WriteLine($"Added {topping}");
            }
        } while (option > 0);
        Console.Write("\n");

        SetPhase("uncooked");
        CalculateBakeTime();
    }
}