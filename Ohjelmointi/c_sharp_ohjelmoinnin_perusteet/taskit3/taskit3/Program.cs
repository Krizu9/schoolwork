using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace taskit3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
             * 
             TEHTÄVÄ 1
            int a = 99;
            if (a > 100)
                Console.WriteLine("EI");
            else
                Console.WriteLine("JOO");

            Console.Read();
            

            //otetaan tietoa käyttäjältä
            Console.WriteLine("Anna kokonaisluku:");
            String x = Console.ReadLine();
            int y = Convert.ToInt16(x);

            if (y > 100)
                Console.WriteLine("on yli 100");
            else
                Console.WriteLine("ei ole yli 100");

            // poikkeusten käsittely


            Console.Read();
            */




            {

                /*
                 
                
                

                 

                //silmukat, luupit, loops
                //for   while   do while
                //tulostetaan "Kokkola" 5 kertaa

                //for
                for (int k = 0; k < 5; k = k + 1)
                {
                    Console.WriteLine("Kokkola ja k:n arvo on " + k);
                }

               
                //while
                int i = 0;
                while(i < 5)
                {
                    Console.WriteLine("Oulu");
                    i = i + 1;
                }

                //do while
                int j = 0;
                do
                {
                    Console.WriteLine("Riihimäki");
                    j = j + 1;
                }
                while (j < 5);
                
                        while (true)
                        {
                            Console.WriteLine("i am sailing...    ");

                        }

                        



                int x = 10;
                x++;



                //sarjoja: 2,4,6,8,10...20

                for (int s = 2; s <= 20; s = s + 2)
                {
                    Console.WriteLine(s);
                }

                // 0.5, 1.5, 4.5, .... 50

                for (double t = 0.5; t <= 50; t = t *3)
                {
                    Console.WriteLine(t);

                }

                //satunnaisluvut
                Random satunnaislukugeneraattori = new Random();
                int luku = satunnaislukugeneraattori.Next(1, 41);
                Console.WriteLine(luku);


                

                //tulosta 10 satunnaislukua väliltä 1 - 100
                for (int p = 0; p < 10; p++)
                {
                    int r = satunnaislukugeneraattori.Next(1, 101);

                    Console.WriteLine(r);

                    Console.WriteLine();
                }

                // lasketaan lukujen summa ja keskiarvo

                int summa = 0;
                for (int p = 0; p < 10; p = p + 1)
                {
                    int r = satunnaislukugeneraattori.Next(1, 101);
                    summa = summa + r;
                }
                float ka = (float) summa / 10;
                Console.WriteLine(summa);
                Console.WriteLine(ka);


                

                TEHTÄVÄ 2
                Console.WriteLine("Anna kokonaisluku:");
                string x = Console.ReadLine();
                double xx = Convert.ToDouble(x);
                string y = Console.ReadLine();
                double yy = Convert.ToDouble(y);

                if ( yy < xx)
                    Console.WriteLine("ensimmäiseksi syötetty numero on isompi kuin jälkeenpäin syötetty numero");
                    else if (yy > xx)
                    Console.WriteLine("jälkeeinpäin syötetty numero on isompi kuin jälkeenpäin syötetty numero");
                    else
                    Console.WriteLine("annetut arvot ovat yhtäsuuria");


                Console.Read();

               
                //tehtävä 3

                Console.WriteLine("Insert day number:");
                string x = Console.ReadLine();
                double xx = Convert.ToDouble(x);

                if (xx == 1)
                    Console.WriteLine("first day of the week is Monday");
                else if (xx == 2)
                    Console.WriteLine("Second day of the week is Tuesday");
                else if (xx == 3)
                    Console.WriteLine("Third day of the week is Wednesday");
                else if (xx == 4)
                    Console.WriteLine("Fourth day of the week is Thursday");
                else if (xx == 5)
                    Console.WriteLine("Fifth day of the week is Friday");
                else if (xx == 6)
                    Console.WriteLine("Sixth day of the week is Saturday");
                else
                        Console.WriteLine("Seventh day of the week is Sunday");


                Console.Read();
                

                TEHTÄVÄ 4
                    Program solves a quadratic equation
                Note: teacher gives more info.
                ax^2 + bx + c = 0

                x1
                
                double a = 4;
                double b = 7;
                double c = 22;

                double diskr = b * b - 4 * a * c;
                if(diskr >= 0)
                {
                    double x1 = (-b + Math.Sqrt(diskr)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(diskr)) / (2 * a);

                    Console.WriteLine(x1);
                    Console.WriteLine(x2);
                }
                else
                    Console.WriteLine("ei ole oikeita juuria");

                Console.Read();


                tehtävä 5

                Console.WriteLine("Insert the number of the month:");
                string x = Console.ReadLine();
                double xx = Convert.ToDouble(x);
                double hel = 28;             //helmikuu 28 päivää
                double tammaatouheielolokjou = 31;          //tammikuu, maaliskuu, toukokuu, heinäkuu, elokuu, lokakuu ja joulukluu 31 päivää
                double huhkessyymar = 30;
                double tammikuu = 1;
                double maaliskuu = 3;
                double huhtikuu = 4;
                double toukokuu = 5;
                double kesakuu = 6;
                double heinakuu = 7;
                double elokuu = 8;
                double syyskuu = 9;
                double lokakuu = 10;
                double marraskuu = 11;
                double joulukuu = 12;


                if (xx== tammikuu ||xx== maaliskuu ||xx == toukokuu || xx == heinakuu ||xx == elokuu || xx == lokakuu || xx == joulukuu)
                    Console.WriteLine("The entered month has " + tammaatouheielolokjou + " days in it");
                else if (xx == huhtikuu || xx == kesakuu || xx == syyskuu || xx == marraskuu)
                    Console.WriteLine("The entered month has " + huhkessyymar + " days in it");
                else
                    Console.WriteLine("The entered month has " + hel + " days in it");


                    Console.Read();

                

                //  tehtävä 6

                Console.WriteLine("syötä haluamasi arvo sivulle A:");
                string a = Console.ReadLine();
                Console.WriteLine("syötä haluamasi arvo sivulle B:");
                string b = Console.ReadLine();
                Console.WriteLine("syötä haluamasi arvo sivulle A:");
                string c = Console.ReadLine();
                double aa = Convert.ToDouble(a);
                double bb = Convert.ToDouble(b);
                double cc = Convert.ToDouble(c);
                double p = aa + bb + cc;
                double y = Math.Sqrt((p / 2)*(p / 2 - aa)*(p / 2 - bb)*(p / 2 - cc));
                

                if (aa == cc && cc == bb)
                    Console.WriteLine("kolmio on tasasivuinen");
                else if (cc == bb || cc == aa || bb == aa)
                    Console.WriteLine("kolmio on tasakylkinen");
                else if (Math.Pow(aa, 2) + Math.Pow(bb, 2) == Math.Pow(cc, 2))
                    Console.WriteLine("kolmio on suorakulmainen");
                else
                    Console.WriteLine("kolmio on tavallinen");



                Console.WriteLine(y);
                Console.Read();


                

                //tehtävä 7
                Console.WriteLine("Syötä ensimmäinen arvo:");
                string a = Console.ReadLine();
                Console.WriteLine("Syötä toinen arvo:");
                string b = Console.ReadLine();
                Console.WriteLine("Syötä kolmas arvo");
                string c = Console.ReadLine();

                int aa = Convert.ToInt16(a);
                int bb = Convert.ToInt16(b);
                int cc = Convert.ToInt16(c);

                if (aa > cc)
                {
                    if (aa > bb)
                    {
                        Console.WriteLine( aa + " arvo on isoin");
                    }
                            else
                            {
                                Console.WriteLine( bb + " arvo on isoin");
                            }
                }
                else if (bb > cc)
                    Console.WriteLine( bb + " arvo on isoin");
                else
                    Console.WriteLine( cc + " arvo on isoin");

                int[] lista = { aa, bb, cc };
                Console.WriteLine(lista.Max() + " arvo on isoin" );

                // en keksi kolmatta vaihtoehtoa



               

                //tehtävä 8


                Console.WriteLine("Syötä pituutesi (muodossa x,xx Metriä):");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Syötä painosi (muodossa x,xx Kg):");
                double weight = Convert.ToDouble(Console.ReadLine());
                double bmi;
                bmi = weight / height / height;

                
                if (0 <= bmi && bmi <= 15)
                    Console.WriteLine("Sairaalloinen alipaino");
                else if (15 <= bmi && bmi <= 17.9)
                    Console.WriteLine("Merkittävä alipaino");
                else if (18 <= bmi && bmi <= 18.9)
                    Console.WriteLine("Lievä alipaino");
                else if (19 <= bmi && bmi <= 24.9)
                    Console.WriteLine("Normaali paino");
                else if (25 <= bmi && bmi <= 29.9)
                    Console.WriteLine("Lievä ylipaino");
                else if (30 <= bmi && bmi <= 34.9)
                    Console.WriteLine("Merkittävä ylipaino");
                else if (35 <= bmi && bmi <= 39.9)
                    Console.WriteLine("Vaikea ylipaino");
                else
                    Console.WriteLine("Sairaalloinen ylipaino");

                    Console.WriteLine("bmi arvosi on " + bmi);
                Console.Read();

                


                //tehtävä 9

                int leapyear;
                Console.Write("Input desired year to check if its a leap year: ");
                leapyear = Convert.ToInt16(Console.ReadLine());

                if ((leapyear % 400) == 0)
                    Console.WriteLine(leapyear + " is a leap year");
                else if ((leapyear % 100) == 0)
                    Console.WriteLine(leapyear + " is not a leap year");
                else if ((leapyear % 4) == 0)
                    Console.WriteLine(leapyear + " is a leap year");
                else
                    Console.WriteLine(leapyear + " is not a leap year");
                 */


                //tehtä

                int numero;
                int muista;
                Console.Write("Input desired number to check if its odd or even: ");
                numero = Convert.ToInt16(Console.ReadLine());
                muista = numero % 2;
                if (muista == 0)
                    Console.WriteLine(numero + " is even integer");
                else
                    Console.WriteLine(numero + " is odd integer");




            }
            Console.Read();

        }













    }

































}


