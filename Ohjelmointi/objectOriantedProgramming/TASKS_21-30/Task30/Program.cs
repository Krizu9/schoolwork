using System;

public interface IMessage
{
    string fromWho { get; set; }
    string toWhom { get; set; }
    string Message { get; set; }
    void Send();
}

public class SmsMessage : IMessage
{
    public string fromWho { get; set; }
    public string toWhom { get; set; }
    public string Message { get; set; }

    public SmsMessage(string from, string to, string message)
    {
        fromWho = from;
        toWhom = to;
        Message = message;
    }

    public void Send()
    {
        Console.WriteLine($"SMS sent from {fromWho} to {toWhom}: {Message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IMessage smsMessage = new SmsMessage("0500123456", "0400123456", "Hello!");
        smsMessage.Send();
    }
}