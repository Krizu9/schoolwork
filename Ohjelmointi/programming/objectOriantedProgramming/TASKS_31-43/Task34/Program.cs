using System;

namespace ArrayCalculatorApp
{
    public static class ArrayCalculator
    {
        public static double Sum(double[] array)
        {
            double sum = 0.0;
            foreach (double d in array)
            {
                sum += d;
            }
            return sum;
        }

        public static double Average(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            double sum = Sum(array);
            return sum / array.Length;
        }

        public static double Min(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            double min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public static double Max(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };

            Console.WriteLine("Sum = " + ArrayCalculator.Sum(array).ToString("F2"));
            Console.WriteLine("Ave = " + ArrayCalculator.Average(array).ToString("F2"));
            Console.WriteLine("Min = " + ArrayCalculator.Min(array).ToString("F2"));
            Console.WriteLine("Max = " + ArrayCalculator.Max(array).ToString("F2"));

            Console.ReadLine();
        }
    }
}


 //Question: How the methods of the ArrayCalcs class work if you pass an empty double[] array as a parameter: double[] array = { };
 //I think my code would return sum and avarage of 0.0, and min/max would return somekind of error, because there is no length of array, and my code uses length of array.