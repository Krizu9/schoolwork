using System;
using System.Collections.Generic;

public abstract class Shape
{
    public string Name { get; set; }

    public abstract double Area();

    public abstract double Circumference();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Circumference()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area()
    {
        return Width * Height;
    }

    public override double Circumference()
    {
        return 2 * (Width + Height);
    }
}

public class Shapes
{
    public List<Shape> AllShapes { get; set; }

    public Shapes()
    {
        AllShapes = new List<Shape>();
    }

    public void AddShape(Shape shape)
    {
        AllShapes.Add(shape);
    }

    public void PrintAllShapes()
    {
        foreach (var shape in AllShapes)
        {
            if (shape is Circle)
            {
                var circle = shape as Circle;
                Console.WriteLine($"Circle Radius={circle.Radius} Area={circle.Area():F2} Circumference={circle.Circumference():F2}");
            }
            else if (shape is Rectangle)
            {
                var rectangle = shape as Rectangle;
                Console.WriteLine($"Rectangle Width={rectangle.Width} Height={rectangle.Height} Area={rectangle.Area():F2} Circumference={rectangle.Circumference():F2}");
            }
        }
        Console.WriteLine("\nPress enter key to continue...");
        Console.ReadLine();
    }
}

public class Program
{
    static void Main()
    {
        var shapes = new Shapes();

        var circle1 = new Circle { Name = "Circle 1", Radius = 1 };
        shapes.AddShape(circle1);

        var circle2 = new Circle { Name = "Circle 2", Radius = 2 };
        shapes.AddShape(circle2);

        var circle3 = new Circle { Name = "Circle 3", Radius = 3 };
        shapes.AddShape(circle3);

        var rectangle1 = new Rectangle { Name = "Rectangle 1", Width = 10, Height = 20 };
        shapes.AddShape(rectangle1);

        var rectangle2 = new Rectangle { Name = "Rectangle 2", Width = 20, Height = 30 };
        shapes.AddShape(rectangle2);

        var rectangle3 = new Rectangle { Name = "Rectangle 3", Width = 40, Height = 50 };
        shapes.AddShape(rectangle3);

        shapes.PrintAllShapes();
    }
}
