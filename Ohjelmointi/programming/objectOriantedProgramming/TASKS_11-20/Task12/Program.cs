using System;

class Tank
{
    private string name;
    private string type;
    private int crewNumber = 4;
    private float speedMax = 100;
    private float speed = 0;

    public Tank(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int CrewNumber
    {
        get { return crewNumber; }
        set
        {
            if (value >= 2 && value <= 6)
            {
                crewNumber = value;
            }
        }
    }

    public float Speed
    {
        get { return speed; }
    }

    public float SpeedMax
    {
        get { return speedMax; }
    }

    public void AccelerateTo(float speed)
    {
        if (speed >= 0 && speed <= speedMax)
        {
            this.speed = speed;
        }
    }

    public void SlowTo(float speed)
    {
        if (speed >= 0 && speed <= speedMax)
        {
            this.speed = speed;
        }
    }
}

class TestTank
{
    static void Main(string[] args)
    {
        Tank myTank = new Tank("Tiger", "Heavy");

        Console.WriteLine("Tank name: " + myTank.Name);
        Console.WriteLine("Tank type: " + myTank.Type);
        Console.WriteLine("Crew number: " + myTank.CrewNumber);

        myTank.CrewNumber = 3;
        Console.WriteLine("New crew number: " + myTank.CrewNumber);

        Console.WriteLine("Maximum speed: " + myTank.SpeedMax);
        Console.WriteLine("Current speed: " + myTank.Speed);

        myTank.AccelerateTo(50);
        Console.WriteLine("Accelerated to speed: " + myTank.Speed);

        myTank.SlowTo(20);
        Console.WriteLine("Slowed down to speed: " + myTank.Speed);

        Console.ReadLine();
    }
}