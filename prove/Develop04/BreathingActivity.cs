class BreathingActivity : Activity
{
    // Attributes
    private int _inDuration;
    private int _outDuration;
    
    // Constructor
    public BreathingActivity(int inDuration, int outDuration)
    {
        SetActivityType(1);
        _inDuration = inDuration;
        _outDuration = outDuration;
    }

    // Methods
    public void RunActivity()
    {
        int breath = _inDuration + _outDuration; // time of one breath
        int duration = GetDuration(); // duration of activity
        int wholeBreaths = duration / breath; // number of whole breaths possible in given time
        int partialBreath = duration % breath; // seconds left over for partial breath

        if (partialBreath == 0) // the duration of the activity is divisible by the time of one breath
        {
            for (int i = 0; i < wholeBreaths; i++)
            {
                Breathe(_inDuration, true);
                Breathe(_outDuration, false);
            }
        }
        else if (partialBreath > 5) // the duration of the activity leaves at least 6 extra seconds of breathing
        {
            // use the extra seconds to add one extra breath that is partial length
            int partialBreatheIn = partialBreath / 2;
            int partialBreatheOut = partialBreath / 2;
            if (partialBreath % 2 == 1)
            {
                partialBreatheOut++;
            }
            Breathe(partialBreatheIn, true);
            Breathe(partialBreatheOut, false);

            for (int i = 0; i < wholeBreaths; i++)
            {
                Breathe(_inDuration, true);
                Breathe(_outDuration, false);
            }
        }
        else // the duration of the activity leaves less than 6 extra seconds of breathing
        {
            // add the extra seconds onto the very last breath
            int finalBreatheIn = _inDuration + (partialBreath / 2);
            int finalBreatheOut = _outDuration + (partialBreath / 2);
            if (partialBreath % 2 == 1)
            {
                finalBreatheOut++;
            }
            // since the length of the final breath will change, the number of normal breaths must also change
            wholeBreaths--;

            for (int i = 0; i < wholeBreaths; i++)
            {
                Breathe(_inDuration, true);
                Breathe(_outDuration, false);
            }

            Breathe(finalBreatheIn, true);
            Breathe(finalBreatheOut, false);
        }
    }
    public void Breathe(int duration, bool breatheIn)
    {
        Spinner breatheCounter = new(duration);
        if (breatheIn)
        {
            Console.Write("Breathe in...");
            breatheCounter.Countdown();
            Console.Write("\n");
        }
        else
        {
            Console.Write("Now breathe out...");
            breatheCounter.Countdown();
            Console.Write("\n\n");
        }
    }
}