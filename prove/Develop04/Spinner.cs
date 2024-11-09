class Spinner
{
    // Attributes
    private int _spinDuration;

    // Constructor
    public Spinner(int spinDuration)
    {
        _spinDuration = spinDuration;
    }

    // Methods
    public void SetSpinDuration(int spinDuration)
    {
        _spinDuration = spinDuration;
    }
    public void Spin()
    {
        List<string> animation = new();
        animation.Add("\\");
        animation.Add("|");
        animation.Add("/");
        animation.Add("-");

        DateTime spinStart = DateTime.Now;
        DateTime spinEnd = spinStart.AddSeconds(_spinDuration);

        int i = 0;
        while (DateTime.Now < spinEnd)
        {
            if (i == animation.Count)
            {
                i = 0;
            }
            string a = animation[i];
            Console.Write(a);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;
        }
    }
    public void Countdown()
    {
        for (int i = _spinDuration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i > 99)
            {
                Console.Write("\b \b");
            }
            if (i > 9)
            {
                Console.Write("\b \b");
            }
            Console.Write("\b \b");
        }
    }
}