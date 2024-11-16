class Circle : Shape
{
    // Attributes
    private double _radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Methods
    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}