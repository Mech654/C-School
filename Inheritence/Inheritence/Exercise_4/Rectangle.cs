namespace Inheritence.Exercise_4;

public class Rectangle : Shape
{
    public double Height { get; set; }
    public double Width { get; set; }

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public override double GetArea()
    {
        return Height * Width;
    }

    public override double GetPerimeter()
    {
        return 2 * (Height + Width);
    }
}