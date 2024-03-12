using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskit_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /* tehtävä 1
             * Create a program that
               a) fills an array with random numbers
               b) prints an array
               c) calculates the sum
               d) calculates the average
               e) finds the max and min
               f) finds a spesific values
               g) tells how many times some value exists in an array

            
 
            int[] t = new int[8];
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                t[i] = rand.Next(20);

            }
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + t[i]);
            }
            int sum = 0;
            for (int i = 0; i < 8; i++)
                {
                sum = sum + t[i];
                 }
            Console.Write(" " + sum);

            double ka = sum / t.Length;

            Console.WriteLine(" \nKeskiarvo on " + ka);
            int max = t[0];
            for (int i = 0; i < 8; i++)
            {
                if (t[i] > max)
                    max = t[i]; 

            }
            Console.WriteLine("maksimi on " + max);

            int min = t[0];
            for (int i = 0; i < 8; i++)
            {
                if (t[i] < min)
                    min = t[i];

            }
            Console.WriteLine("minimi on " + min);

            int tulos = -1;
            int etsi = 9;
            for (int i = 0; i < 8; i++)
                 {
                   if ( t[i] == etsi)
                    {
                    tulos = i;
                    break;
                
                    }

                     }
            if (tulos == -1 )
                Console.WriteLine("tulos 9 ei löytynyt");
            else Console.WriteLine("tulos 9 löytyi");

            int arvoesiintyy = 0;
            int arvoesiintyi = 10;
            for (int i = 0; i < 8; i++)
            {
                if (t[i] == arvoesiintyi)
                    arvoesiintyy++;
            }
            Console.WriteLine("Numero 10 esiintyy " + arvoesiintyy + " kertaa");
            console.Read();
            */

            //tehtävä 2
            /*
            Console.WriteLine("syötä haluamasi arvo jolla kerrotaan kahdeksan numeroa");
            string x = Console.ReadLine();
            int kerroin = Convert.ToInt16(x);
            
            int[] t = new int[8];
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                t[i] = rand.Next(20);
                int vastaus = t[i] * kerroin;
                Console.WriteLine(vastaus);
            }
            
            Console.ReadLine();
            */
            /*
            //Tehtävä 3


            int[] taulukko = new int[3];
            taulukko[0] = 120;
            taulukko[1] = 50;
            taulukko[2] = taulukko[0] + taulukko[1];
            Console.WriteLine(taulukko[2]);

            Console.Read();

            */
            //tehtävä 4
            /*

            int[,] taulukko = new int[5,3];
            taulukko[0,0] = 120;
            taulukko[0,1] = 50;
            taulukko[0,2] = 122;
            taulukko[1,1] = 56;
            taulukko[1,2] = 129;
            taulukko[2,0] = 42;
            taulukko[2,1] = 172;
            taulukko[2,2] = 12;
            taulukko[3,0] = 44;
            taulukko[3,1] = 142;
            taulukko[3,2] = 10;
            taulukko[4,0] = 83;

            for (int r = 0; r < 4; r++)
            {
                for (int s = 0; s < 3; s++)
                    Console.Write(" " + taulukko[r, s]);
                Console.WriteLine();
            }
            */
            //tehtävä 5

            /*

            long[,] taulukko = new long[6,6];
            taulukko[0,0] = 5873000000;
            taulukko[0,1] = 6115000000;
            taulukko[0,2] = 6513000000;
            taulukko[0,3] = 6923000000;
            taulukko[0,4] = 7341000000;
            taulukko[1,0] = 1997;
            taulukko[1,1] = 2000;
            taulukko[1,2] = 2005;
            taulukko[1,3] = 2010;
            taulukko[1,4] = 2015;
            

            for (int r = 0; r < 2; r++)
            {
                for (int s = 0; s < 5; s++)
                    Console.Write(" " + taulukko[r,s]);
                Console.WriteLine();

            }

            */








            /*
             //tehtävä 6
             
            

            
            double[,] maat = { { 5500000 },
                               {338000  },
                               {0} };
            maat[2, 0] = maat[0, 0] / maat[1, 0];
            Console.WriteLine(maat[2, 0]);

            */

            //Tehtävä 7
            
            int[,] taulukko = new int[6, 6];
            taulukko[0, 0] = 1;
            taulukko[0, 1] = 5;
            taulukko[0, 2] = 6;
            taulukko[0, 3] = 6;
            taulukko[0, 4] = 7;
            taulukko[0, 5] = 7;
            taulukko[1, 0] = 2;
            taulukko[1, 1] = 4;
            taulukko[1, 2] = 6;
            taulukko[1, 3] = 8;
            taulukko[1, 4] = 8;
            taulukko[1, 5] = 8;
            taulukko[2, 0] = 3;
            taulukko[2, 1] = 5;
            taulukko[2, 2] = 5;
            taulukko[2, 3] = 8;
            taulukko[2, 4] = 6;
            taulukko[2, 5] = 8;
            taulukko[3, 0] = 4;
            taulukko[3, 1] = 9;
            taulukko[3, 2] = 6;
            taulukko[3, 3] = 8;
            taulukko[3, 4] = 5;
            taulukko[3, 5] = 8;
            taulukko[4, 0] = 5;
            taulukko[4, 1] = 7;
            taulukko[4, 2] = 6;
            taulukko[4, 3] = 7;
            taulukko[4, 4] = 8;
            taulukko[4, 5] = 10;


            for (int r = 0; r < 5; r++)
            {
                for (int s = 0; s < 6; s++)
                    Console.Write(" " + taulukko[r, s]);
                Console.WriteLine();

                
            //tehtävä 8
            /*
            int[,] taulukko = new int[6, 6];
            taulukko[0, 0] = 1;
            taulukko[0, 1] = 2;
            taulukko[0, 2] = 5;
            taulukko[0, 3] = 8;
            taulukko[0, 4] = 4;
            taulukko[0, 5] = 2;
            taulukko[1, 0] = 3;
            taulukko[1, 1] = 22;
            taulukko[1, 2] = 33;
            taulukko[1, 3] = 11;
            taulukko[1, 4] = 0;
            taulukko[1, 5] = 5;


            for (int r = 0; r < 4; r++)
            {
                for (int s = 0; s < 3; s++)
                    Console.Write(" " + taulukko[r, s]);
                Console.WriteLine();
            }
            
                */
           


            Console.Read();
            }
        }
    }
}