using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kertaus
{
    class Program
    {
        static void Main(string[] args)
        {
            // ++ -- 
            /* int a = 10;
            a++; // a = a + 1
            Console.WriteLine(a);

            int b = ++a;
            Console.WriteLine(b);

            b = a++;
            Console.WriteLine(b);
            Console.WriteLine(a);


            Console.WriteLine(b++);
            Console.WriteLine(b);


            // += -= /= *§/ %
            int c = 20;
            c += 30;
            
            */

            /*
            for (int i = 1; i <= 21; i = i +2)
            {
                Console.WriteLine(i);
            }
            // tulostetaan "Helsinki" 5 kertaa
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("helsinki");
            }

            // 9, 7.5, 6.0, ... 0
            for (double j = 9; j >=0; j = j - 1.5)
            {
                Console.WriteLine(j);
            }

            //lukumäärä ja keskiarvo
            //1, 1.5, 2, ... 30
            int n = 0;
            double summa = 0;
            for (double j = 1; j <= 30; j = j + 0.5)
            {
                n++;
                summa += j;

            }
            double ka = summa / n;
            Console.WriteLine("summa on " + summa);
            Console.WriteLine("keskiarvo on " + ka);

            Random rand = new Random();
            //generoidaan 20 satunnaislukua, jotka ovat väliltä 1- 10
            for (int i = 0; i < 20; i++)
            {
                Console.Write("  " + rand.Next(1, 11    ));
            }   

            //while
            int k = 0;
            while (k < 20)
            {
                Console.WriteLine("  " + rand.Next(1,11));
                k++;

            }

            // do while
            int p = 0;
            do
            {
                Console.Write("  " + rand.Next(1, 11));
                p++;
            } while (p < 20);

            15
            *program calculates the sum of values 1-5
            use: for, while and do-while
            */
            /*
            //for
            int s1 = 0;
            for (int i= 1; i <= 5; i++)
            {
                s1 = s1 + i;

            }
            Console.WriteLine(s1);

            //while
            int s2 = 0;
            int jj = 1;
            while (jj <= 5)
            {
                s2 = s2 + jj;
                jj++;
            }

            Console.WriteLine(s2);

            //do while
            int s3 = 0;
            int ii = 0;
            do
            {
                s3 = s3 + ii;
                ii++;


            } while (ii <= 5);
            Console.WriteLine(s3);
            Console.Read();
            

            int a = 0;
            for (int aa= 2; aa <= 40; aa = aa + 2)
            {
                a = a + aa;
            }
            Console.WriteLine(a);
            Console.WriteLine();


            int b = 0;
            int bb = 2;
            while (bb <= 40)
            {
                b = b + bb;
                bb = bb + 2; 

            }while (bb <= 40);
            Console.WriteLine(b);



            int c = 0;
            int cc = 2;

            do
            {
                c = c + cc;
                cc = cc+2;


            } while (cc <= 40);
            Console.WriteLine(c);
            Console.Read();

            */

            //taulukot
            int[] luvut = new int[5];
            luvut[0] = 50;
            luvut[1] = 99;
            luvut[2] = -33;
            luvut[3] = 0;
            luvut[4] = 77;

            Console.WriteLine(luvut[0]);
            Console.WriteLine(luvut[1]);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(luvut[i]);
            }

            //alustaminen
            string[] nimet = { "kai", "mia", "tea", "lea" };
            int koko = nimet.Length;

            for (int i = 0; i < koko; i++)
            {
                Console.WriteLine(nimet[i]);

            }

            //luo taulukko, johon laitetaan 50 satunnaislukua väliltä 1-50
            int[] numerot = new int[50];

            Random rand = new Random();
            
            for (int i = 0; i < 50; i++)
            {
                numerot[i] = rand.Next(1, 11);

            }

            for (int i = 0; i < 50; i++)
            {

                Console.WriteLine(numerot[i]);
            }

            //2-ulottoinen taulukko: rivit ja sarakkeet
            int[,] matrsiisi = new int[2, 3];

            matrsiisi[0, 0] = 1;
            matrsiisi[0, 1] = 2;
            matrsiisi[0, 2] = 3;

            matrsiisi[1, 0] = 55;
            matrsiisi[1, 1] = 66;
            matrsiisi[1, 2] = 77;
            
            for (int r = 0; r < 2; r++)
            {
                for (int s = 0; s < 3; s++)
                    Console.Write("   " + matrsiisi[r, s]);
                Console.WriteLine();

            }











            Console.Read();
        }
    }
}
