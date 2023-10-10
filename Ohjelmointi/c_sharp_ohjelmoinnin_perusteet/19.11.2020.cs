using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funkiot
{
    class Program
    {
        //funktio tulostaa "Kokkola"
        static void tulostaKokkola()
        {
            Console.WriteLine("Kokkola");
        }

        static void tulostaNimi(String nimi)
        {
            Console.WriteLine(nimi);
        }

        static void tulostaNimiMontaKertaa(string nimi, int n)  //funktio tulostaa halutun nimen monta kertaa
        {
            for ( int i = 0; i < n; i++)
            {
                Console.WriteLine(nimi);
            }
        }

        //funktio palauttaa 4 kokonaisluvun keskiarvon
        static float ka4(int a, int b, int c, int d)
        {
            float tulos = (float) (a + b + c + d) / 4;
            return tulos; 
        }

        static string onkoParitonVaiParillinen(int x)
        {
            if (x % 2 == 0)
                return "Parillinen";
            else
                return "Pariton";

        }

        //funktiolle vietävä arvo viedään periaatteella "arvona vieminen"
        static void kerroVitosella(int a)
        {
            a = a * 5;
            Console.WriteLine(a);

        }

        static void kerroVitosellaTodella(ref int a)
        {
            a = a * 5;
            Console.WriteLine(a);

        }

        //taulukko parametrina
        //täytetään satunnaisluvuilla Random
        static void laitaArvot(int[] luvut)
        {
            Random rand = new Random();
            int pituus = luvut.Length;
            for (int i = 0; i < pituus; i++)
            {
                luvut[i] = rand.Next(51); // 0 - 50
            }

        }


        //tulostus
        static void tulostaArvot(int[] luvut)
        {
            int pituus = luvut.Length;
            for (int i = 0; i < pituus; i++)
            {
                Console.Write("  " + luvut[i]);
            }


        }

        //palauttaa tiedon siitä, kuinka moni arvoista on
        //väliltä 5 - 15 rajat mukaanlukien
        static int montako_5_15(int[] luvut)
        {
            int pituus = luvut.Length;
            int n = 0;
            for (int i = 0; i < pituus; i++)
            {
                if (luvut[i] >= 5 && luvut[i] <= 15)
                    n++;
            }
            return n;
        }


        static void Main(string[] args)
        {
            int[] arvot = new int[20];
            laitaArvot(arvot); //ei jakasulkuja
            tulostaArvot(arvot);
            Console.WriteLine();

            int montako = montako_5_15(arvot);
            Console.WriteLine(montako);

            /*
            //funktiot, metodit
            tulostaKokkola();
            tulostaNimi("kennedy");
            tulostaNimi("Oulu");
            tulostaNimiMontaKertaa("Riihimäki", 10);

            string tulos = onkoParitonVaiParillinen(3);
            Console.WriteLine(tulos);
            int luku = 4;
            tulos = onkoParitonVaiParillinen(luku);
            Console.WriteLine(tulos);

            Console.WriteLine(onkoParitonVaiParillinen(9));

            float ka = ka4(3, 4, 5, 6);
            Console.WriteLine(ka);
            int a = 20;
            Console.WriteLine(a);
            kerroVitosella(a);
            Console.WriteLine(a);

            kerroVitosellaTodella(ref a);
            Console.WriteLine(a);
            */



            Console.Read();
        }
    }
}
