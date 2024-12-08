abstract class WarmItem : Item
{
    // Attributes
    private int _bakeTime;

    // Constructors
    public WarmItem(int bakeTime)
    {
        _bakeTime = bakeTime;
    }

    // Methods
    public int GetBakeTime()
    {
        return _bakeTime;
    }
    public void Bake()
    {
        SetPhase("baking");
        // wait the bake time

        SetPhase("ready");
    }
}