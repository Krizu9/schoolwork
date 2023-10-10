using System;

class Amplifier
{
    private int volume = 0;

    public bool setVolume(int volume, out string message)
    {
        if (volume < 0)
        {
            this.volume = 0;
            message = "Volume set to minimum (0)";
            return true;
        }
        else if (volume > 100)
        {
            message = "Volume set too high, please enter a number between 0 and 100";
            return false;
        }
        else
        {
            this.volume = volume;
            message = "Amplifier volume is set to " + this.volume;
            return true;
        }
    }

    public int getVolume()
    {
        return volume;
    }
}

class amplifier
{
    static void Main(string[] args)
    {
        Amplifier myAmp = new Amplifier();
        Console.WriteLine("Current volume: " + myAmp.getVolume());
        while (true)
        {
            Console.Write("Give a new volume value (0-100): ");

            if (!int.TryParse(Console.ReadLine(), out int newVolume))
            {
                Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
                continue;
            }

            if (myAmp.setVolume(newVolume, out string message))
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(message);
                continue;
            }
        }
    }
}