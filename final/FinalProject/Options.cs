class Options
{
    // Attributes
    private List<string> _customers;
    private List<PizzaType> _pizzaTypes;
    private List<string> _breadSeasonings;
    private List<string> _wingSauces;
    private List<string> _sodaBases;
    private List<string> _sodaFlavors;
    private List<string> _pizzaToppings;

    // Constructors
    public Options()
    {
        _customers = new();
        _pizzaTypes = new();
        _breadSeasonings = new();
        _wingSauces = new();
        _sodaBases = new();
        _sodaFlavors = new();
        _pizzaToppings = new();
    }

    // Methods
    public string GetToppingAtIndex(int ind)
    {
        return _pizzaToppings[ind];
    }
    public List<string> GetRandomCustomers(int number)
    {
        // this one needs to be returned as a list to avoid the chance of getting the same customer twice in one day
        // number : the number of random customers needed when calling the function
        Random rng = new Random();
        List<string> shuffle = _customers;
        shuffle = shuffle.OrderBy(x => Random.Shared.Next()).ToList();

        List<string> returnList = new();
        for (int i = 0; i < number; i++)
        {
            returnList.Add(shuffle[i]);
        }

        return returnList;
    }
    public PizzaType GetRandomPizzaType()
    {
        // pizza types can be repeated; only one is necessary at a time
        Random rng = new Random();
        List<PizzaType> shuffle = _pizzaTypes;
        shuffle = shuffle.OrderBy(x => Random.Shared.Next()).ToList();

        return shuffle[0];
    }
    public string GetRandomBreadSeasoning()
    {
        // bread seasonings can be repeated; only one is necessary at a time
        Random rng = new Random();
        List<string> shuffle = _breadSeasonings;
        shuffle = shuffle.OrderBy(x => Random.Shared.Next()).ToList();

        return shuffle[0];
    }
    public string GetRandomWingSauce()
    {
        // wing sauces can be repeated; only one is necessary at a time
        Random rng = new Random();
        List<string> shuffle = _wingSauces;
        shuffle = shuffle.OrderBy(x => Random.Shared.Next()).ToList();

        return shuffle[0];
    }
    public string GetRandomSodaBase()
    {
        // soda bases can be repeated; only one is necessary at a time
        Random rng = new Random();
        List<string> shuffle = _sodaBases;
        shuffle = shuffle.OrderBy(x => Random.Shared.Next()).ToList();

        return shuffle[0];
    }
    public List<string> GetRandomSodaFlavors(int number)
    {
        // this one needs to be returned as a list to avoid the chance of getting multiple of the same flavor in one soda
        // number : the number of random soda flavors needed when calling the function
        Random rng = new Random();
        List<string> shuffle = _sodaFlavors;
        shuffle = shuffle.OrderBy(x => Random.Shared.Next()).ToList();

        List<string> returnList = new();
        for (int i = 0; i < number; i++)
        {
            returnList.Add(shuffle[i]);
        }

        return returnList;
    }
    public void AddCustomer(string customer)
    {
        _customers.Add(customer);
    }
    public void AddPizzaType(PizzaType pizzaType)
    {
        _pizzaTypes.Add(pizzaType);
    }
    public void AddBreadSeasoning(string breadSeasoning)
    {
        _breadSeasonings.Add(breadSeasoning);
    }
    public void AddWingSauce(string wingSauce)
    {
        _wingSauces.Add(wingSauce);
    }
    public void AddSodaBase(string sodaBase)
    {
        _sodaBases.Add(sodaBase);
    }
    public void AddSodaFlavor(string sodaFlavor)
    {
        _sodaFlavors.Add(sodaFlavor);
    }
    public void AddPizzaTopping(string pizzaTopping)
    {
        _pizzaToppings.Add(pizzaTopping);
    }
}