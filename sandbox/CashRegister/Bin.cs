class Bin
{
    // Attributes
    private string _denomination;
    private int _amount;
    private float _value;

    // Constructor (has the same name as the class)
    public Bin(string denomination, int amount, float value)
    {
        _denomination = denomination;
        _amount = amount;
        _value = value;
    }

    // Methods
    public void ModifyAmount(int amount)
    {
        _amount += amount;
    }
    public float TotalValue()
    {
        return _amount * _value;
    }
}