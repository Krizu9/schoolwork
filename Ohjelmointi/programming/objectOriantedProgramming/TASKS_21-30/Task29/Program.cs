using System;
using System.Collections.Generic;

public interface ITransaction
{
    string ShowTransaction();
    float Money { get; set; }
}

public class paidWithCash : ITransaction
{
    private static float cashRegister = 0;
    private int billNumber;
    private DateTime date;
    private float money;

    public paidWithCash(int billNumber, DateTime date, float money)
    {
        this.billNumber = billNumber;
        this.date = date;
        this.money = money;
        cashRegister += money;
    }

    public string ShowTransaction()
    {
        return $"Paid with cash: bill number {billNumber} date {date.ToString("d.M.yyyy")} amount {money:F2} Euros";
    }

    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    public static float showCash()
    {
        return cashRegister;
    }
}

public class paidWithCard : ITransaction
{
    private static List<paidWithCard> transactions = new List<paidWithCard>();
    private string cardNumber;
    private DateTime date;
    private float money;

    public paidWithCard(string cardNumber, DateTime date, float money)
    {
        this.cardNumber = cardNumber;
        this.date = date;
        this.money = money;
        transactions.Add(this);
    }

    public string ShowTransaction()
    {
        return $"Transaction to bank: charge from card {cardNumber} date {date.ToString("d.M.yyyy")} amount {money:F2} Euros";
    }

    public float Money
    {
        get { return money; }
        set { money = value; }
    }

    public static float showTotal()
    {
        float total = 0;
        foreach (paidWithCard transaction in transactions)
        {
            total += transaction.Money;
        }
        return total;
    }
}

public class CashRegisterProgram
{
    static void Main(string[] args)
    {
        DateTime today = new DateTime(2020, 1, 1);

        paidWithCash bill1 = new paidWithCash(1, today, 100);
        paidWithCash bill2 = new paidWithCash(2, today, 50);

        paidWithCard card1 = new paidWithCard("4321567890121234", today, 78.95f);
        paidWithCard card2 = new paidWithCard("1234567891234567", today, 45.65f);

        float totalSales = paidWithCash.showCash() + paidWithCard.showTotal();

        Console.WriteLine(card1.ShowTransaction());
        Console.WriteLine(card2.ShowTransaction());
        Console.WriteLine($"Total money at bank account: {paidWithCard.showTotal():F2}");

        Console.WriteLine(bill1.ShowTransaction());
        Console.WriteLine(bill2.ShowTransaction());
        Console.WriteLine($"Total money in cash: {paidWithCash.showCash():F2}");

        Console.WriteLine($"Total sales today {today.ToString("dddd MMMM d, yyyy")} is {totalSales} Euros");

        Console.WriteLine("Program completed successfully. Press any key to quit.");
        Console.ReadKey();
    }
}
