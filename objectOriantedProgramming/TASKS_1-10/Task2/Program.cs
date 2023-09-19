using System;
using System.Text.RegularExpressions;

namespace HillJumping
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] stylePoints = new int[5];
            
            string points;
            int addPoints;
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Give points: ");
                points = Console.ReadLine();
                if (string.IsNullOrEmpty(points) == true || Regex.IsMatch(points, @"[a-zA-Z]") == true)
                {
                    Console.WriteLine("Syöttämäsi arvo ei ollut luku.");
                    i--;
                }
                else
                {
                    addPoints = Convert.ToInt32(points);
                    stylePoints[i] = addPoints;
                    
                }
            }
            Array.Sort(stylePoints);
            for (int i = 1; i < 4; i++)
            {
                sum = sum + stylePoints[i];

            }
            Console.WriteLine("Total points are " + sum);
        }
    }
}