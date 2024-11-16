class Square : Shape
{
    // Attributes
    private double _side;

    // Constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Methods
    public override double GetArea()
    {
        return _side * _side;
    }
}