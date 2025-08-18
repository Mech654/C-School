using System;
using System.Collections.Generic;

namespace Inheritence.Exercise_4;

public class Program
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Circle(3),
            new Rectangle(2, 8)
        };

        double totalArea = 0;

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Area: {shape.GetArea():F2}");
            Console.WriteLine($"Perimeter: {shape.GetPerimeter():F2}");
            totalArea += shape.GetArea();
            Console.WriteLine();
        }

        Console.WriteLine($"Total area of all shapes: {totalArea:F2}");
    }
}

