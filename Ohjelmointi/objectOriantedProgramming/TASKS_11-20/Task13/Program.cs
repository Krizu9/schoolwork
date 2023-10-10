using System;

class Elevator
{
    private int floor = 1;

    public bool GoTo(int floor, out string message)
    {
        if (floor >= 1 && floor <= 5)
        {
            this.floor = floor;
            message = "Elevator moved to floor " + floor;
            return true;
        }
        else
        {
            message = "Invalid floor number. Elevator cannot move.";
            return false;
        }
    }

    public int Floor
    {
        get { return floor; }
    }
}

class ElevatorController
{
    static void Main(string[] args)
    {
        Elevator myElevator = new Elevator();
        Console.WriteLine("Elevator is now in floor " + myElevator.Floor);
        while (true)
        {
            Console.Write("Give a new floor number (1-5): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int floor))
            {
                string message;
                if (myElevator.GoTo(floor, out message))
                {
                    Console.WriteLine("Elevator is now in floor: " + myElevator.Floor);
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
    }
}