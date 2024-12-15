class Order
{
    // Attributes
    private string _status;
    private int _timeStart;
    private string _customer;
    private List<Item> _items;
    private int _timeAvailable;
    private bool _orderDeleted;

    // Constructors
    public Order(int timeStart, string customer)
    {
        // Used when making the order list
        _status = "hidden";
        _timeStart = timeStart;
        _customer = customer;
        _items = new();
        _orderDeleted = false;
    }

    // Methods
    public string GetStringForMenu()
    {
        // string timeStr = String.Format("{0:000}", _timeStart);;
        // string orderStr = $"#{timeStr} {_customer} -";
        string orderStr = string.Format("#{0:000} {1,-10}-", _timeStart, _customer);
        int itemCount = _items.Count;
        int i = 1;
        foreach (Item item in _items)
        {
            orderStr += $" {item.GetStringForMenu()}";
            if (i < itemCount)
            {
                orderStr += " |";
            }
            i++;
        }
        orderStr += $" ] - {_timeAvailable} secs";

        return orderStr;
    }
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
        _status = status;
        if (status == "first try")
        {
            // Time to start counting down
            Thread d = new Thread(TimeCountDown);
            d.Start();
        }
    }
    public void AddItem(Item item)
    {
        // Used when making the original order list
        _items.Add(item);
    }
    public void CalculateTimeAvailable()
    {
        // the time added for each of these
        const int PIZZA_TIME = 20;
        const int TOPPING_TIME = 2;
        const int BREAD_TIME = 9; // 13 for 6pc, 17 for 12pc
        const int WING_TIME = 10; // 15 for 8pc, 20 for 16pc
        const int SODA_TIME = 7;
        const int FLAVOR_TIME = 1;

        // the extra time added on top of everything else
        const int DEFAULT_TIME = 30;

        _timeAvailable = 0;
        foreach (Item item in _items)
        {
            string cat = item.GetCategory();
            switch (cat)
            {
                case "Pizza":
                    Pizza pizza = (Pizza)item;
                    int toppingNum = pizza.GetToppingNum();
                    _timeAvailable += PIZZA_TIME + (TOPPING_TIME * toppingNum);
                    break;
                case "Bread":
                    Bread bread = (Bread)item;
                    int breadAdd = bread.GetQuantity() * 2 / 3;
                    _timeAvailable += BREAD_TIME + breadAdd;
                    break;
                case "Wings":
                    Wings wings = (Wings)item;
                    int wingsAdd = wings.GetQuantity() * 5 / 8;
                    _timeAvailable += WING_TIME + wingsAdd;
                    break;
                default:
                    Soda soda = (Soda)item;
                    int flavorNum = soda.GetFlavorNum();
                    _timeAvailable += SODA_TIME + (FLAVOR_TIME * flavorNum);
                    break;
            }
        }
        _timeAvailable += DEFAULT_TIME;
    }
    public void TimeCountDown()
    {
        bool restartActive = _status == "first try";
        bool restart = false;

        while (_timeAvailable > 0 && !restart && !_orderDeleted)
        {
            if (restartActive && _status == "second try")
            {
                restart = true;
            }
            else
            {
                Thread.Sleep(1000);
                _timeAvailable--;
            }
        }
        if (_timeAvailable == 0)
        {
            _status = "expired";
        }
    }
    public int GetPaid()
    {
        int subtotal = 0;
        foreach (Item item in _items)
        {
            subtotal += item.GetPrice();
        }
        int salesTax = subtotal * 8 / 100;
        int tip = subtotal / 5;
        
        int total = subtotal + salesTax + tip;

        // Display payment
        string subtotalStr = string.Format("{0,6:0.00}", (double)subtotal/100);
        string salesTaxStr = string.Format("{0,6:0.00}", (double)salesTax/100);
        string tipStr = string.Format("{0,6:0.00}", (double)tip/100);
        string totalStr = string.Format("{0,6:0.00}", (double)total/100);
        Console.WriteLine("Here's the money you earned from the order:\n\n");
        Console.WriteLine($"   SUBTOTAL - ${subtotalStr}");
        Console.WriteLine($"  SALES TAX - ${salesTaxStr}");
        Console.Write($"        TIP - ${tipStr}\n\n");
        Console.Write($"      TOTAL - ${totalStr}");

        return total;
    }
    public void SecondChance()
    {
        _status = "second try";

        CalculateTimeAvailable();
        _timeAvailable = _timeAvailable * 4 / 5;
        // Restart the clock with a shorter time
        Thread e = new Thread(TimeCountDown);
        e.Start();

    }
    public void OrderDeleted()
    {
        _orderDeleted = true;
    }
}