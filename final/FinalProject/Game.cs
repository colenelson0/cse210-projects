class Game
{
    // Attributes
    private Player _you;
    private Options _options;
    private int _gameDays;
    private int _day;
    private int _waitTime;
    private bool _failure;

    // Constructors
    public Game(int playerLives, int gameDays, int dayStart, int waitTime)
    {
        _you = new(playerLives);
        _options = new();
        _gameDays = gameDays;
        _day = dayStart;
        _waitTime = waitTime;
        _failure = false;
    }

    // Methods
    public void SetOptions()
    {
        // This method will refer to different text files to add the options for each available item to the _options attribute.
    }
    public void GameDay()
    {
        // This method will run one game day.
        int time = 0;                       // Initial ingame time
        int dayEarnings = 0;                // Initial earnings
        int dayOrdersDone = 0;              // Initial number of orders done

        List<Order> orders = new();
        SetOrders(orders);
        List<Order> orderQueue = new();     // Initial order queue for completion
        List<Item> deck = new();            // Initial items being worked on.
    }
    public void SetOrders(List<Order> orderList)
    {
        // This method will add a set number of random orders to random time slots. The number and complexity of the orders will be determined by the game day.
    }
    public void DisplayDayClock(int t)
    {
        // This method will write the ingame time t to the console as a formatted string.
    }
    public void DisplayLives()
    {
        // This method will write the number of lives left as to the console as a formatted string.
        // Lives: [ ] [ ] [ ]
        // Lives: [ ] [X] [X]
        int playerLives = _you.GetLives();
    }
    public void DisplayDeckStatus(List<Item> itemList)
    {
        // This method will display all the item phases and the number of items in each phase.
    }
    public void PushOrder(List<Order> newOrders, int t, List<Order> orderList)
    {
        // This method will search the order list newOrders until an order is found that is set to be pushed to orderList at the current time t.
    }
    public void DisplayOrderQueue(List<Order> orderList)
    {
        // This method will display all the unfinished orders. 
    }
    public void ComposeItem(List<Item> itemList)
    {
        // Present the options for what items can be composed

        // Create the item

        // Add the item to the list
    }
    public void BakeItem(List<Item> itemList)
    {
        // Present the options for what items can be baked

        // Bake the selected item
    }
    public void DisposeItem(List<Item> itemList)
    {
        // List the items that have been composed

        // Remove the chosen item from the list
    }
    public string SubmitItems(List<Item> itemList, List<Order> orderList)
    {
        return "evaluation";
    }
    public void TimeIncrement(int t)
    {
        // This method will wait the specified amount of time _waitTime and then increment the ingame time t by one.
    }
    public void EndDayTransfer(int earnings, int ordersDone)
    {
        // This method will transfer the earned money and completed orders to the player's total for each.
    }
    public void DisplayGameFail()
    {
        // :(
    }
}