using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // haarautuminen
            //if else
            int a = 10;
            if (a > 0)
                Console.WriteLine("on");
            else
                Console.WriteLine("ei");
            //vertailuoperaattori
            //>  >=     <     <=     ==      !=
            Console.WriteLine(a > 0);

            //loogiset operaattorit
            // || tai, && JA,    ! EI

            //onko a väliltä 0 - 10 rajat mukaanlukien [0,10]
            if (a >= 0)
                if (a <= 10)
                    Console.WriteLine("On joo");
                else
                    Console.WriteLine("EI OO");
            else
                Console.WriteLine("EI OO");

            //tapa 2
            if (a < 0 && a <= 10)
                Console.WriteLine("EI OO");
            else
                Console.WriteLine("EI OO ");

            //monta vaihtoehtoa
            //muuttujassa nro väliltä 0 - 5
            //ohjelma kertoo nimen italiaksi
            int b = 3;
            if (b == 0)
                Console.WriteLine("Zero");
            else if (b == 1)
                Console.WriteLine("Uno");
            else if (b == 2)
                Console.WriteLine("due");
            else if (b == 3)
                Console.WriteLine("tri");
            else if (b == 4)
                Console.WriteLine("quattro");
            else if (b == 5)
                Console.WriteLine("cinquit");
            else
                Console.WriteLine("ei sopivaa arvo");

            //switch case
            switch (b)
            {
                case 0: Console.WriteLine("zero"); break;
                case 1: Console.WriteLine("uno"); break;
                case 2: Console.WriteLine("due"); break;
                case 3: Console.WriteLine("tri"); break;
                case 4: Console.WriteLine("quattro"); break;
                case 5: Console.WriteLine("cinquit"); break;
                default: Console.WriteLine("ei sopiva arvo");break;







                Console.Read();
            }


            Console.Read();
        }
    }
}
