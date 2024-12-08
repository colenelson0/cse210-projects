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
    public Soda(string sodaBase)
    {
        // For the starting order list
        SetCategory("Soda");
        _sodaBase = sodaBase;
        _flavors = new();
    }

    // Methods
    public string GetSodaBase()
    {
        return _sodaBase;
    }
    public List<string> GetFlavors()
    {
        return _flavors;
    }
    public void AddFlavor(string flavor)
    {
        // For the starting order list
        _flavors.Add(flavor);
    }
    public override void Compose()
    {
        // Set soda base and add flavors from user input

        SetPhase("ready");
    }
}