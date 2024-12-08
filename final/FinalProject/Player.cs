class Player
{
    // Attributes
    private int _lives;
    private int _totalEarnings;
    private int _totalOrdersDone;

    // Constructors
    public Player(int lives)
    {
        _lives = lives;
        _totalEarnings = 0;
        _totalOrdersDone = 0;
    }

    // Methods
    public int GetLives()
    {
        return _lives;
    }
    public int GetTotalEarnings()
    {
        return _totalEarnings;
    }
    public int GetTotalOrdersDone()
    {
        return _totalOrdersDone;
    }
    public bool LoseLife()
    {
        _lives--;

        return _lives < 1;
    }
    public void TransferEarnings(int earnings)
    {
        _totalEarnings += earnings;
    }
    public void TransferOrdersDone(int ordersDone)
    {
        _totalOrdersDone += ordersDone;
    }
}