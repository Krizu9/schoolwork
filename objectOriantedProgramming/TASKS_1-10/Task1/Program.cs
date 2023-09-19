
using System.Text.RegularExpressions;

class Task1
{
        static void Main(string[] args)
        {


        string luku;
        Console.WriteLine("Give points: ");
        luku = Console.ReadLine();
        
        if (string.IsNullOrEmpty(luku) == true || Regex.IsMatch(luku, @"[a-zA-Z]") == true)
        {
            Console.WriteLine("Syöttämäsi arvo ei ollut luku.");
        }
        else
        {
            int arvosana = Convert.ToInt32(luku);
            if (arvosana > 0 && arvosana < 20) { Console.WriteLine("Your grade is: 0"); }
            if (arvosana > 19 && arvosana < 30) { Console.WriteLine("Your grade is: 1"); }
            if (arvosana > 29 && arvosana < 40) { Console.WriteLine("Your grade is: 2"); }
            if (arvosana > 39 && arvosana < 50) { Console.WriteLine("Your grade is: 3"); }
            if (arvosana > 49 && arvosana < 60) { Console.WriteLine("Your grade is: 4"); }
            if (arvosana > 59 && arvosana < 71) { Console.WriteLine("Your grade is: 5"); }
            if (arvosana > 70) { Console.WriteLine("Points can't be higher than 70 points."); }
        }












        }
    }