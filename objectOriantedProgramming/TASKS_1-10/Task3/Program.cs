using System;

namespace Consumption
{
    class Program
    {
        static void CalculateCost(double distance)
        {
            Random r = new Random();
            double consumption = 6 + (9 - 6) * r.NextDouble();
            double fuelPrice = 1.75 + (2.50 - 1.75) * r.NextDouble();
            double totalFuelConsumed = distance / 100 * consumption;
            double totalCost = totalFuelConsumed * fuelPrice;
            Console.WriteLine("Fuel consumption is " + Math.Round(totalFuelConsumed,2) +  " liters and it costs " + Math.Round(totalCost,2) + " euros.");
            
        }

        static void Main(string[] args)
        {
            Console.Write("Enter distance traveled: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double distance))
            {
                CalculateCost(distance);
            }
            else
            {
                Console.WriteLine("Invalid input. Input must be a number.");
            }
        }
    }
}