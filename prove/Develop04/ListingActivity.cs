class ListingActivity : Activity
{
    // Attributes
    private List<string> _prompts;
    private int _itemCount;
    
    // Constructor
    public ListingActivity(List<string> prompts)
    {
        SetActivityType(3);
        _prompts = prompts;
        _itemCount = 0;
    }

    // Methods
    public void RunActivity()
    {
        Random rng = new Random();

        // shuffle the prompts
        _prompts = _prompts.OrderBy(x => Random.Shared.Next()).ToList();

        InitialPrompt(_prompts[0]);

        // sets the time interval using DateTime
        DateTime listStart = DateTime.Now;
        DateTime listEnd = listStart.AddSeconds(GetDuration());
        while (DateTime.Now < listEnd)
        {
            Console.Write("> ");
            Console.ReadLine();
            _itemCount++;
        }

        // stop and display the number of listed items
        DisplayItemCount();
    }
    public void InitialPrompt(string prompt)
    {
        Spinner listCounter = new(5);

        Console.Write("List as many response as you can to the following prompt:\n\n");
        Console.Write($" --- {prompt} ---\n\n");
        Console.Write("You may begin in: ");
        listCounter.Countdown();
        Console.Write("\n");
    }
    public void DisplayItemCount()
    {
        Console.Write($"You listed {_itemCount} items!\n\n");
    }
}