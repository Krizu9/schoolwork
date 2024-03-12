using System;

class ElectricalDevice
{
    public bool On { get; set; }
    public float Power { get; set; }
}

class PortableRadio : ElectricalDevice
{
    private int volume;
    private float frequency;

    public int Volume
    {
        get { return volume; }
        set
        {
            if (On)
            {
                volume = value;
                Console.WriteLine("Volume set to " + volume);
            }
            else
            {
                Console.WriteLine("Please turn on the radio before setting the volume.");
            }
        }
    }

    public float Frequency
    {
        get { return frequency; }
        set
        {
            if (On)
            {
                if (value >= 2000.0f && value <= 26000.0f)
                {
                    frequency = value;
                    Console.WriteLine("Frequency set to " + frequency);
                }
                else
                {
                    Console.WriteLine("Invalid frequency value. Please set a value between 2000 and 26000.");
                }
            }
            else
            {
                Console.WriteLine("Please turn on the radio before setting the frequency.");
            }
        }
    }

    public override string ToString()
    {
        return "On: " + On + "\nPower: " + Power + "\nVolume: " + Volume + "\nFrequency: " + Frequency;
    }
}

class Program
{
    static void Main(string[] args)
    {
        PortableRadio radio = new PortableRadio();

        radio.On = true;
        radio.Power = 10;

        Console.WriteLine(radio.ToString());

        radio.Volume = 5;
        radio.Frequency = 10000;

        Console.WriteLine(radio.ToString());
    }
}