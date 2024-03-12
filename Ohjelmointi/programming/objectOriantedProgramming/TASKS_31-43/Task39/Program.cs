using System;

class Timer
{
    public int Time { get; set; }
    public string AlarmNotification { get; set; }

    public Timer(int time, string alarmNotification)
    {
        Time = time;
        AlarmNotification = alarmNotification;
    }

    public void Start()
    {
        Console.WriteLine("Timer started for {0} seconds.", Time);

        // Convert time to milliseconds
        int timeInMillis = Time * 1000;
        System.Threading.Thread.Sleep(timeInMillis);

        Console.WriteLine(AlarmNotification);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Do you want to set the timer in seconds or minutes? (s/m): ");
        string input = Console.ReadLine();

        int time;
        string timeUnit;
        if (input == "s")
        {
            timeUnit = "seconds";
            Console.Write("Enter the number of seconds (1-60): ");
            time = int.Parse(Console.ReadLine());
        }
        else
        {
            timeUnit = "minutes";
            Console.Write("Enter the number of minutes (1-60): ");
            time = int.Parse(Console.ReadLine()) * 60;
        }

        if (time < 1 || time > 60 * 60)
        {
            Console.WriteLine("Invalid input. Time must be between 1 second and 60 minutes.");
            return;
        }

        Console.Write("Enter alarm notification (default is \"Wake wake, the little bird\"): ");
        string alarmNotification = Console.ReadLine();
        if (string.IsNullOrEmpty(alarmNotification))
        {
            alarmNotification = "Wake wake, the little bird";
        }

        Timer timer = new Timer(time, alarmNotification);
        timer.Start();
    }
}
