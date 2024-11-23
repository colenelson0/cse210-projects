class SimpleGoal : Goal
{
    // Attributes
    private bool _complete;

    // Constructor
    public SimpleGoal()
    {
        SetGoalType("SimpleGoal");
        _complete = false;
    }

    // Methods
    public override string GetTextForFile()
    {
        return $"{_type}:{_name},{_description},{_points},{_complete}";
    }
    public void SetComplete(bool complete)
    {
        _complete = complete;
    }
    public override int RecordEvent()
    {
        _complete = true;
        return _points;
    }
    public override bool IsComplete()
    {
        return _complete;
    }
}