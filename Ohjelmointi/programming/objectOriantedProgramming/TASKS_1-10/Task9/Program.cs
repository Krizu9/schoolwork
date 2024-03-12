using System;

public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Speed { get; set; }
    public int Tires { get; set; }

    public Vehicle(string brand, string model, int speed, int tires)
    {
        Brand = brand;
        Model = model;
        Speed = speed;
        Tires = tires;
    }

    public string ShowInfo()
    {
        return $"Manufacturer: {Brand}\nModel: {Model}";
    }

    public string GetAllProperties()
    {
        return $"Manufacturer: {Brand}\nModel: {Model}\nSpeed: {Speed}\nTires: {Tires}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle car = new Vehicle("Mercedes Benz","W210",230,4);
        Vehicle motorcycle = new Vehicle("Kawasaki","Ninja H2",400,2);
        Vehicle bicycle = new Vehicle("Nopsa", "Mondo", 7, 2);
        Vehicle truck = new Vehicle("Scania", "S730", 90, 4);

        car.Model = "W124";
        car.Speed = 180;

        Console.WriteLine("Bicycle info:\n" + bicycle.ShowInfo());
        Console.WriteLine(" ");
        Console.WriteLine("All bicycle properties:\n" + bicycle.GetAllProperties());
        Console.WriteLine(" ");
        Console.WriteLine("Motorcycle info:\n" + motorcycle.ShowInfo());
        Console.WriteLine(" ");
        Console.WriteLine("All motorcycle properties:\n" + motorcycle.GetAllProperties());
        Console.WriteLine(" ");
        Console.WriteLine("Car info:\n" + car.ShowInfo());
        Console.WriteLine(" ");
        Console.WriteLine("All car properties:\n" + car.GetAllProperties());
        Console.WriteLine(" ");
        Console.WriteLine("truck info:\n" + truck.ShowInfo());
        Console.WriteLine(" ");
        Console.WriteLine("All truck properties:\n" + truck.GetAllProperties());

    }
}