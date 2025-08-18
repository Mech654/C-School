namespace Inheritence.Exercise_4;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return 3.14159 * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * 3.14159 * Radius;
    }
}