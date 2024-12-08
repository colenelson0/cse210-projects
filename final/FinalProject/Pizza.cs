class Pizza : WarmItem
{
    // Attributes
    private string _pizzaType;
    private List<string> _toppings;

    // Constructors
    public Pizza(int bakeTime) : base(bakeTime)
    {
        // For user input
        SetCategory("Pizza");
        _toppings = new();
    }
    public Pizza(int bakeTime, PizzaType pizzaType) : base(bakeTime)
    {
        // For the starting order list
        SetCategory("Pizza");
        _pizzaType = pizzaType.GetTypeName();
        _toppings = pizzaType.GetToppings();
    }

    // Methods
    public string GetPizzaType()
    {
        return _pizzaType;
    }
    public List<string> GetToppings()
    {
        return _toppings;
    }
    public override void Compose()
    {
        // A default pizza type will be assigned for simplicity
        _pizzaType = "User";

        // Set toppings from user input

        SetPhase("uncooked");
    }
}