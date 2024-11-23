class Reward
{
    // Attributes
    private string _name;
    private string _description;
    private int _requiredPoints;
    private bool _rewardEarned;

    // Constructor
    public Reward()
    {
        _rewardEarned = false;
    }

    // Methods
    public virtual string GetTextForUser()
    {
        string checkbox;
        if (_rewardEarned)
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }
        return $"{checkbox} {_name} ({_description})";
    }
    public string GetTextForFile()
    {
        return $"Reward:{_name},{_description},{_requiredPoints},{_rewardEarned}";
    }
    public int GetRequiredPoints()
    {
        return _requiredPoints;
    }
    public bool GetRewardEarned()
    {
        return _rewardEarned;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public void SetRequiredPoints(int requiredPoints)
    {
        _requiredPoints = requiredPoints;
    }
    public void SetRewardEarned(bool rewardEarned)
    {
        _rewardEarned = rewardEarned;
    }
    public void EarnReward()
    {
        Console.WriteLine("You have reached the required number of points to earn the following reward:");
        Console.WriteLine($"{_name}: {_description}");
        Console.Write("Enjoy your reward and keep moving forward with your goals!\n\n");

        _rewardEarned = true;
    }
}