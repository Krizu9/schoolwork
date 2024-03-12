using System;

public class Tire
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string TireSize { get; set; }
}

public class Vehicle
{
    public string Name { get; set; }
    public string Model { get; set; }
    public List<Tire> Tires { get; set; }

    public Vehicle()
    {
        Tires = new List<Tire>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle car = new Vehicle();
        car.Name = "Mercedes Benz";
        car.Model = "W124";

        Tire carTire = new Tire();
        carTire.Manufacturer = "Nokia";
        carTire.Model = "Hakkapeliitta";
        carTire.TireSize = "195/65R15";

        for (int i = 0; i < 4; i++)
        {
            car.Tires.Add(carTire);
            Console.WriteLine("Tire {0} added to vehicle {1}", i + 1, car.Name);
        }

        Console.WriteLine("\nVehicle Name: {0} Model: {1} has tires:", car.Name, car.Model);
        foreach (Tire tire in car.Tires)
        {
            Console.WriteLine("-Name: {0} Model: {1} TireSize: {2}", tire.Manufacturer, tire.Model, tire.TireSize);
        }

        
        Vehicle motorcycle = new Vehicle();
        motorcycle.Name = "Kawasaki";
        motorcycle.Model = "Ninja H2";

        Tire motoTire1 = new Tire();
        motoTire1.Manufacturer = "Michelin";
        motoTire1.Model = "Road5";
        motoTire1.TireSize = "120/70ZR17";

        Tire motoTire2 = new Tire();
        motoTire2.Manufacturer = "Michelin";
        motoTire2.Model = "Road5";
        motoTire2.TireSize = "200/55ZR17";

        motorcycle.Tires.Add(motoTire1);
        motorcycle.Tires.Add(motoTire2);

        Console.WriteLine("\nVehicle Name: {0} Model: {1} has tires:", motorcycle.Name, motorcycle.Model);
        foreach (Tire tire in motorcycle.Tires)
        {
            Console.WriteLine("-Name: {0} Model: {1} TireSize: {2}", tire.Manufacturer, tire.Model, tire.TireSize);
        }
    }
}
