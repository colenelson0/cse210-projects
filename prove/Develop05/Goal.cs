
abstract class Goal
{
    // Attributes
    protected string _type;
    protected string _name;
    protected string _description;
    protected int _points;

    // Constructor
    public Goal() {}

    // Methods
    public virtual string GetTextForUser()
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
        return $"{checkbox} {_name} ({_description})";
    }
    public virtual string GetTextForFile()
    {
        return $"{_type}:{_name},{_description},{_points}";
    }
    public string GetName()
    {
        return _name;
    }
    public void SetGoalType(string type)
    {
        _type = type;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }
    public void SetPoints(int points)
    {
        _points = points;
    }
    public virtual int RecordEvent()
    {
        return _points;
    }
    public virtual bool IsComplete()
    {
        return false;
    }
}