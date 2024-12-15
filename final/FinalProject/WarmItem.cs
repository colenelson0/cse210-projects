abstract class WarmItem : Item
{
    // Attributes
    private int _bakeTime;

    // Constructors
    public WarmItem() {}

    // Methods
    public abstract void CalculateBakeTime();
    public void SetBakeTime(int bakeTime)
    {
        _bakeTime = bakeTime * 1000;
    }
    public void Bake()
    {
        SetPhase("baking");

        // wait the bake time
        Thread b = new Thread(ThreadBake);
        b.Start();
    }
    public void ThreadBake()
    {
        Thread.Sleep(_bakeTime);

        // done baking
        SetPhase("ready");
    }
}