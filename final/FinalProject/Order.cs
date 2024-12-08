class Order
{
    // Attributes
    private string _status;
    private int _timeStart;
    private string _customer;
    private List<Item> _items;
    private int _timeAvailable;

    // Constructors
    public Order(int timeStart, string customer)
    {
        // Used when making the original order list
        _timeStart = timeStart;
        _customer = customer;
        _items = new();
    }

    // Methods
    public string GetStatus()
    {
        return _status;
    }
    public int GetTimeStart()
    {
        return _timeStart;
    }
    public string GetCustomer()
    {
        return _customer;
    }
    public List<Item> GetItems()
    {
        return _items;
    }
    public void SetStatus(string status)
    {
        // Used when pushing the order to the order queue
        _status = status;
    }
    public void AddItem(Item item)
    {
        // Used when making the original order list
        _items.Add(item);
    }
    public void CalculateTimeAvailable()
    {
        //
    }
    public void StartClock()
    {
        int ms = _timeAvailable * 1000;

        //
    }
}