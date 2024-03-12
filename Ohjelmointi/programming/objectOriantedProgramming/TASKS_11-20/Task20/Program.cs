using System;

public abstract class Mammal
{
    public int Age { get; set; }

    public abstract void Move();
}

public class Human : Mammal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }

    public override void Move()
    {
        Console.WriteLine("Moving");
    }

    public void Grow()
    {
        Age++;
    }
}

public class Baby : Human
{
    public string Diaper { get; set; }

    public override void Move()
    {
        Console.WriteLine("Crawling");
    }
}

public class Adult : Human
{
    public string Auto { get; set; }

    public override void Move()
    {
        Console.WriteLine("Walking");
    }
}

class Program
{
    static void Main(string[] args)
    {

        Human jaana = new Adult() { Name = "jaana", Weight = 70.5, Height = 1.7, Auto = "Mercedes", Age = 30 };
        Human jarkko = new Baby() { Name = "jarkko", Weight = 9.2, Height = 0.6, Diaper = "Pampers", Age = 1 };
        Adult daniel = new Adult() { Name = "daniel", Weight = 80.3, Height = 1.8, Auto = "BMW", Age = 35 };

        Console.WriteLine($"Name: {jaana.Name}, Age: {jaana.Age}, Weight: {jaana.Weight}, Height: {jaana.Height}, Auto: {((Adult)jaana).Auto}");
        Console.WriteLine($"Name: {jarkko.Name}, Age: {jarkko.Age}, Weight: {jarkko.Weight}, Height: {jarkko.Height}, Diaper: {((Baby)jarkko).Diaper}");
        Console.WriteLine($"Name: {daniel.Name}, Age: {daniel.Age}, Weight: {daniel.Weight}, Height: {daniel.Height}, Auto: {daniel.Auto}");

        jaana.Move();
        jaana.Grow();
        jarkko.Move();
        jarkko.Grow();
        daniel.Move();
        daniel.Grow();

        Console.WriteLine($"Name: {jaana.Name}, Age: {jaana.Age}, Weight: {jaana.Weight}, Height: {jaana.Height}, Auto: {((Adult)jaana).Auto}");
        Console.WriteLine($"Name: {jarkko.Name}, Age: {jarkko.Age}, Weight: {jarkko.Weight}, Height: {jarkko.Height}, Diaper: {((Baby)jarkko).Diaper}");
        Console.WriteLine($"Name: {daniel.Name}, Age: {daniel.Age}, Weight: {daniel.Weight}, Height: {daniel.Height}, Auto: {daniel.Auto}");
    }
}