class Wings : WarmItem
{
    // Attributes
    private int _quantity;
    private string _sauce;

    // Constructors
    public Wings(int bakeTime) : base(bakeTime)
    {
        // For user input
        SetCategory("Wings");
    }
    public Wings(int bakeTime, bool qOption, string sauce) : base(bakeTime)
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
    public int GetQuantity()
    {
        return _quantity;
    }
    public string GetSauce()
    {
        return _sauce;
    }
    public override void Compose()
    {
        // Set quantity and sauce from user input

        SetPhase("uncooked");
    }
}