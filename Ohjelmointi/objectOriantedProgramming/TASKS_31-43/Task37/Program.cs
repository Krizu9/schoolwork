using System;

namespace DiceRoller
{
    class Dice
    {
        private Random random = new Random();

        public int Roll()
        {
            return random.Next(1, 7);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();

            int result = dice.Roll();
            Console.WriteLine($"Dice, one test throw value is {result}\n");

            Console.Write("How many times you want to throw a dice: ");
            int throwCount = int.Parse(Console.ReadLine());

            int total = 0;
            int[] counts = new int[6];

            for (int i = 0; i < throwCount; i++)
            {
                int roll = dice.Roll();
                total += roll;
                counts[roll - 1]++;
            }

            double average = (double)total / throwCount;
            

            Console.WriteLine("\nNumber of occurrences of all the numbers thrown:");
            Console.WriteLine($"Dice is now thrown {throwCount} times, average is {average:F4}");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"- {i + 1} count is {counts[i]}");
            }

        }
    }
}
