class Options
{
    // Attributes
    private List<string> _customers;
    private List<PizzaType> _pizzaTypes;
    private List<string> _breadSeasonings;
    private List<string> _wingSauces;
    private List<string> _sodaBases;
    private List<string> _sodaFlavors;

    // Constructors
    public Options()
    {
        _customers = new();
        _pizzaTypes = new();
        _breadSeasonings = new();
        _wingSauces = new();
        _sodaBases = new();
        _sodaFlavors = new();
    }

    // Methods
    public List<string> GetRandomCustomers(int number)
    {
        // this one needs to be returned as a list to avoid the chance of getting the same customer twice in one day
        // number : the number of random customers needed when calling the function

        // temp
        List<string> customerList = new();
        return customerList;
    }
    public PizzaType GetRandomPizzaType()
    {
        // pizza types can be repeated; only one is necessary at a time

        // temp
        PizzaType pizzaType = new("typeName");
        return pizzaType;
    }
    public string GetRandomBreadSeasoning()
    {
        // bread seasonings can be repeated; only one is necessary at a time

        // temp
        string breadSeasoning = "breadSeasoning";
        return breadSeasoning;
    }
    public string GetRandomWingSauce()
    {
        // wing sauces can be repeated; only one is necessary at a time

        // temp
        string wingSauce = "wingSauce";
        return wingSauce;
    }
    public string GetRandomSodaBase()
    {
        // soda bases can be repeated; only one is necessary at a time

        // temp
        string sodaBase = "sodaBase";
        return sodaBase;
    }
    public List<string> GetRandomSodaFlavors(int number)
    {
        // this one needs to be returned as a list to avoid the chance of getting multiple of the same flavor in one soda
        // number : the number of random soda flavors needed when calling the function

        // temp
        List<string> sodaFlavors = new();
        return sodaFlavors;
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
}