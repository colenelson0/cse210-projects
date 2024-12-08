class PizzaType
{
    // Attributes
    private string _typeName;
    private List<string> _toppings;

    // Constructors
    public PizzaType(string typeName)
    {
        _typeName = typeName;
        _toppings = new();
    }

    // Methods
    public string GetTypeName()
    {
        return _typeName;
    }
    public List<string> GetToppings()
    {
        return _toppings;
    }
    public void AddTopping(string topping)
    {
        _toppings.Add(topping);
    }
}