using System;

class Vehicle
{
    private string name;
    private string model;
    private int year;
    private string color;

    public Vehicle(string name, string model, int year, string color)
    {
        this.name = name;
        this.model = model;
        this.year = year;
        this.color = color;
    }

    public override string ToString()
    {
        return $"{name} {model}, {year}, {color}";
    }
}

class Bicycle : Vehicle
{
    private bool geared;
    private string gearbox;

    public Bicycle(string name, string model, int year, string color, bool geared, string gearbox) : base(name, model, year, color)
    {
        this.geared = geared;
        this.gearbox = gearbox;
    }

    public bool isGeared()
    {
        return geared;
    }

    public string getGearbox()
    {
        return gearbox;
    }

    public override string ToString()
    {
        string gearedText = geared ? "geared" : "not geared";
        return $"{base.ToString()} ({gearedText}, {gearbox})";
    }
}

class Boat : Vehicle
{
    private string type;
    private int seats;

    public Boat(string name, string model, int year, string color, string type, int seats) : base(name, model, year, color)
    {
        this.type = type;
        this.seats = seats;
    }

    public string getType()
    {
        return type;
    }

    public int getSeats()
    {
        return seats;
    }

    public override string ToString()
    {
        return $"{base.ToString()} ({type}, {seats} seats)";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle vehicle1 = new Vehicle("Toyota", "Corolla", 2022, "blue");
        Console.WriteLine(vehicle1.ToString());
        Console.WriteLine();

        Bicycle bicycle1 = new Bicycle("Trek", "FX 2 Disc", 2021, "black", true, "Shimano Altus");
        Console.WriteLine(bicycle1.ToString());
        Console.WriteLine($"Is geared: {bicycle1.isGeared()}");
        Console.WriteLine($"Gearbox: {bicycle1.getGearbox()}\n");

        Boat boat1 = new Boat("Lund", "Pro-V Bass XS", 2022, "red", "motor boat", 3);
        Console.WriteLine(boat1.ToString());
        Console.WriteLine($"Boat type: {boat1.getType()}");
        Console.WriteLine($"Number of seats: {boat1.getSeats()}");
    }
}