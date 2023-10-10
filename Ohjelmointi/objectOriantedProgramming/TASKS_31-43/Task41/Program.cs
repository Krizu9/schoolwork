using System;
using System.Collections.Generic;
using System.Linq;

public class Fish
{
    public string species;
    public double length;
    public double weight;
    public string place;
    public string location;
    public Fisher caughtBy;

    public override string ToString()
    {
        return $"{species} {length} cm {weight} kg\n - place: {place}\n - location: {location}\n - Fisherman: {caughtBy.name}";
    }
}

public class Fisher
{
    public string name;
    public string phone;
    public List<Fish> catches;

    public Fisher(string name, string phone)
    {
        this.name = name;
        this.phone = phone;
        this.catches = new List<Fish>();
    }

    public override string ToString()
    {
        return $"Fisherman: {name} Phone: {phone}";
    }

    public void AddFish(Fish fish)
    {
        catches.Add(fish);
        fish.caughtBy = this;
    }
}

public class FishRegister
{
    public List<Fisher> fishers;

    public FishRegister()
    {
        this.fishers = new List<Fisher>();
    }

    public void AddFisher(Fisher fisher)
    {
        fishers.Add(fisher);
        Console.WriteLine($"A new Fisherman added to Fish-register:\n - {fisher}\n");
    }

    public void AddFishTo(Fisher fisher, Fish fish)
    {
        fisher.AddFish(fish);
        Console.WriteLine($"\nFisher : {fisher.name} got a new fish\n - {fish}");
    }

    public void PrintAllFish()
    {
        Console.WriteLine("\nAll fish in register:\n");
        foreach (var fisher in fishers)
        {
            Console.WriteLine($"Fisherman {fisher.name} has got following fish:");
            foreach (var fish in fisher.catches)
            {
                Console.WriteLine($" - {fish}\n");
            }
        }
        Console.WriteLine("\nPress enter key to continue...");
        Console.ReadLine();
    }

    public void PrintSortedFish()
    {
        Console.WriteLine("\nSorted register\n");
        var sortedFish = fishers.SelectMany(f => f.catches).OrderByDescending(f => f.weight);
        foreach (var fish in sortedFish)
        {
            Console.WriteLine($" - {fish}");
        }
        Console.WriteLine("Press enter key to continue...");
        Console.ReadLine();
    }
}

public class MyFishApp
{
    static void Main()
    {
        var fishRegister = new FishRegister();

        var kirsiKernel = new Fisher("Kirsi Kernel", "050-12345678");
        fishRegister.AddFisher(kirsiKernel);

        var danielKärppä = new Fisher("Daniel Kärppä", "040-5678910");
        fishRegister.AddFisher(danielKärppä);

        var pike = new Fish
        {
            species = "Pike",
            length = 120,
            weight = 4.5,
            place = "Seinäjärvi",
            location = "Virrat"
        };
        fishRegister.AddFishTo(kirsiKernel, pike);

        var salmon = new Fish
        {
            species = "Salmon",
            length = 190,
            weight = 13.2,
            place = "Inarijärvi",
            location = "Inari"
        };
        fishRegister.AddFishTo(danielKärppä, salmon);
        var perch = new Fish
        {
            species = "Perch",
            length = 35,
            weight = 0.4,
            place = "Seinäjärvi",
            location = "Virrat"
        };
        fishRegister.AddFishTo(kirsiKernel, perch);

        var trout = new Fish
        {
            species = "Trout",
            length = 45,
            weight = 1.2,
            place = "Oulujoki",
            location = "Oulu"
        };
        fishRegister.AddFishTo(danielKärppä, trout);

        fishRegister.PrintAllFish();

        fishRegister.PrintSortedFish();
    }
}
