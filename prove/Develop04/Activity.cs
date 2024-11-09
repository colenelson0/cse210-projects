class Activity
{
    // Attributes
    private int _type;
    private int _duration;

    // Constructor
    public Activity()
    {
        
    }

    // Methods
    public int GetActivityType()
    {
        return _type;
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void SetActivityType(int type)
    {
        _type = type;
    }
    public void SetDuration(int duration)
    {
        _duration = duration;
    }
    public void DisplayWelcome()
    {
        int type = GetActivityType();
        Console.Clear();
        if (type == 1)
        {
            Console.Write("Welcome to the Breathing Activity.\n\n");
            Console.Write("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.\n\n");
        }
        else if (type == 2)
        {
            Console.Write("Welcome to the Reflecting Activity.\n\n");
            Console.Write("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n\n");
        }
        else
        {
            Console.Write("Welcome to the Listing Activity.\n\n");
            Console.Write("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n\n");
        }

        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(Console.ReadLine());
        SetDuration(duration);
    }
    public void DisplayGetReady()
    {
        Spinner readySpinner = new(5);

        Console.Clear();
        Console.WriteLine("Get ready...");
        readySpinner.Spin();
        Console.Write("\n");
    }
    public void DisplayWellDone()
    {
        int seconds = GetDuration();
        int type = GetActivityType();
        Spinner readySpinner = new(5);

        Console.WriteLine("Well done!!");
        readySpinner.Spin();
        if (type == 1)
        {
            Console.Write($"\nYou have completed another {seconds} seconds of the Breathing Activity.\n");
        }
        else if (type == 2)
        {
            Console.Write($"\nYou have completed another {seconds} seconds of the Reflecting Activity.\n");
        }
        else
        {
            Console.Write($"\nYou have completed another {seconds} seconds of the Listing Activity.\n");
        }
        readySpinner.Spin();
    }
}