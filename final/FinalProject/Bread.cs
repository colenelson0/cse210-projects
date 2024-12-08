class Bread : WarmItem
{
    // Attributes
    private int _quantity;
    private string _seasoning;

    // Constructors
    public Bread(int bakeTime) : base(bakeTime)
    {
        // For user input
        SetCategory("Bread");
    }
    public Bread(int bakeTime, bool qOption, string seasoning) : base(bakeTime)
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
    public int GetQuantity()
    {
        return _quantity;
    }
    public string GetSeasoning()
    {
        return _seasoning;
    }
    public override void Compose()
    {
        // Set quantity and seasoning from user input

        SetPhase("uncooked");
    }
}