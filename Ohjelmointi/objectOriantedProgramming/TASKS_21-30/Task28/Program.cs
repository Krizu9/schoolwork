using System;
using System.Collections.Generic;

class Food
{
    public string Name { get; set; }
    public DateTime ExpirationDate { get; set; }

    public Food(string name, DateTime expirationDate)
    {
        Name = name;
        ExpirationDate = expirationDate;
    }

    public bool isExpired()
    {
        return DateTime.Now > ExpirationDate;
    }

    public override string ToString()
    {
        return string.Format("{0} ({1})", Name, ExpirationDate.ToShortDateString());
    }
}

class Refrigerator
{
    private List<Food> contents = new List<Food>();

    public void addFood(Food food)
    {
        contents.Add(food);
    }

    public void removeFood(Food food)
    {
        contents.Remove(food);
    }

    public List<Food> getExpiredFood()
    {
        var expiredFood = new List<Food>();
        foreach (var food in contents)
        {
            if (food.isExpired())
            {
                expiredFood.Add(food);
            }
        }
        return expiredFood;
    }

    public List<Food> getFoodByName(string name)
    {
        var foodByName = new List<Food>();
        foreach (var food in contents)
        {
            if (food.Name.ToLower() == name.ToLower())
            {
                foodByName.Add(food);
            }
        }
        return foodByName;
    }

    public override string ToString()
    {
        var str = "Refrigerator contents:\n";
        foreach (var food in contents)
        {
            str += "- " + food.ToString() + "\n";
        }
        return str;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var refrigerator = new Refrigerator();

        var milk = new Food("Milk", new DateTime(2023, 4, 5));
        var cheese = new Food("Cheese", new DateTime(2023, 4, 10));
        var carrots = new Food("Carrots", new DateTime(2023, 3, 31));
        var apples = new Food("Atria microwavepizza", new DateTime(2023, 4, 2));

        refrigerator.addFood(milk);
        refrigerator.addFood(cheese);
        refrigerator.addFood(carrots);
        refrigerator.addFood(apples);

        Console.WriteLine(refrigerator);

        var expiredFood = refrigerator.getExpiredFood();
        Console.WriteLine("Expired food:");
        foreach (var food in expiredFood)
        {
            Console.WriteLine("- " + food.ToString());
        }

        var cheeseByName = refrigerator.getFoodByName("Cheese");
        foreach (var food in cheeseByName)
        {
            Console.WriteLine("- " + food.ToString());
        }

        refrigerator.removeFood(apples);
        Console.WriteLine(refrigerator);
    }
}
