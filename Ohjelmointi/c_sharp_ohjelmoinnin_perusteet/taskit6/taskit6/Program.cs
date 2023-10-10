using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskit6
{
    class Program
    {
        static void Main(string[] args)
        {
            string sanoma = " mayday";
            int pituus = sanoma.Length;
            char merkki = sanoma.ElementAt(0);

            if (merkki == 'M')
                Console.WriteLine("-- ");
            for (int i = 0; i < pituus; i++)
            {
                if (sanoma.ElementAt(i) == 'A')
                    Console.WriteLine(".- ");
                else if (sanoma.ElementAt(i) == 'B')
                    Console.WriteLine("-... ");
                else if (sanoma.ElementAt(i) == 'C')
                    Console.WriteLine("-.-. ");
                else if (sanoma.ElementAt(i) == 'D')
                    Console.WriteLine("-.. ");
                else if (sanoma.ElementAt(i) == 'E')
                    Console.WriteLine(". ");
                else if (sanoma.ElementAt(i) == 'F')
                    Console.WriteLine("..-. ");
                else if (sanoma.ElementAt(i) == 'G')
                    Console.WriteLine("--. ");


            }



        }
    }
}
