abstract class Item
{
    // Attributes
    private string _category;
    private string _phase;
    private int _price;

    // Constructors
    public Item()
    {
        _phase = "empty"; // Item needs to be composed
    }

    // Methods
    public string GetCategory()
    {
        return _category;
    }
    public string GetPhase()
    {
        return _phase;
    }
    public int GetPrice()
    {
        return _price;
    }
    public void SetCategory(string category)
    {
        // not to be used outside child class constructors
        _category = category;
    }
    public void SetPhase(string phase)
    {
        // used in game when actions are taken
        _phase = phase;
    }
    public void SetPrice(int price)
    {
        _price = price;
    }
    public abstract void Compose();
}