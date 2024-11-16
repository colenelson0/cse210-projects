using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();
        shapes.Add(new Square("forest green", 3));
        shapes.Add(new Rectangle("scarlet", 2, 4));
        shapes.Add(new Circle("cool blue", 1.8));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"color: {color}, area: {area}");
        }
    }
}