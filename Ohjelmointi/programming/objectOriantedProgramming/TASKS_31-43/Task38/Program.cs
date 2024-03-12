using System;

namespace Task38
{
    class Window
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public const double GlassLayerThickness = 0.005;
        public const double WoodThickness = 0.03;

        public Window(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            double frameArea = (Width + Height) * 2 * WoodThickness;
            double glassArea = (Width - 2 * WoodThickness) * (Height - 2 * WoodThickness) * 3;
            return frameArea + glassArea;
        }

        public double GetCircumference()
        {
            double frameCircumference = (Width + Height) * 2;
            double glassCircumference = (Width + Height - 4 * WoodThickness) * 2 * 3;
            return frameCircumference + glassCircumference;
        }

        public double GetUsageInSquareMeters()
        {
            return GetArea() + (Width * Height - GetArea()) * GlassLayerThickness;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the width of the window in meters: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("\nEnter the height of the window in meters: ");
            double height = double.Parse(Console.ReadLine());

            Window window = new Window(width, height);

            Console.WriteLine($"\nArea of the window: {window.GetArea():F2} square meters");
            Console.WriteLine($"Circumference of the window: {window.GetCircumference():F2} meters");
            Console.WriteLine($"Window usage: {window.GetUsageInSquareMeters():F2} square meters");
        }
    }
}
