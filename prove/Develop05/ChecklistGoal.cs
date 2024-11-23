class ChecklistGoal : Goal
{
    // Attributes
    private int _bonus;
    private int _timesNeeded;
    private int _times;

    // Constructor
    public ChecklistGoal()
    {
        SetGoalType("ChecklistGoal");
        _times = 0;
    }

    // Methods
    public override string GetTextForUser()
    {
        string checkbox;
        if (IsComplete())
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }
        return $"{checkbox} {_name} ({_description}) -- Currently completed: {_times}/{_timesNeeded}";
    }
    public override string GetTextForFile()
    {
        return $"{_type}:{_name},{_description},{_points},{_bonus},{_timesNeeded},{_times}";
    }
    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }
    public void SetTimesNeeded(int timesNeeded)
    {
        _timesNeeded = timesNeeded;
    }
    public void SetTimes(int times)
    {
        _times = times;
    }
    public override int RecordEvent()
    {
        _times++;

        if (_times == _timesNeeded)
        {
            return _points + _bonus;
        }
        else
        {
            return _points;
        }
    }
    public override bool IsComplete()
    {
        return _times == _timesNeeded;
    }
}