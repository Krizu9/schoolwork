using System;

public class Item
{
    private string title;
    private string publisher;
    private float price;

    public Item(string title, string publisher, float price)
    {
        this.title = title;
        this.publisher = publisher;
        this.price = price;
    }

    public string getTitle()
    {
        return title;
    }

    public string getPublisher()
    {
        return publisher;
    }

    public float getPrice()
    {
        return price;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Title: {title}, Publisher: {publisher}, Price: ${price}.");
    }
}

public class Book : Item
{
    private int pages;
    private string genre;

    public Book(string title, string publisher, float price, int pages, string genre) : base(title, publisher, price)
    {
        this.pages = pages;
        this.genre = genre;
    }

    public int getPages()
    {
        return pages;
    }

    public string getGenre()
    {
        return genre;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Pages: {pages}, Genre: {genre}");
    }
}

public class Magazine : Item
{
    private string date;

    public Magazine(string title, string publisher, float price, string date) : base(title, publisher, price)
    {
        this.date = date;
    }

    public string getDate()
    {
        return date;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Date: {date}");
    }
}

public class Phone : Item
{
    private string manufacturer;
    private int storage;
    private int ram;

    public Phone(string title, string publisher, float price, string manufacturer, int storage, int ram) : base(title, publisher, price)
    {
        this.manufacturer = manufacturer;
        this.storage = storage;
        this.ram = ram;
    }

    public string getManufacturer()
    {
        return manufacturer;
    }

    public int getStorage()
    {
        return storage;
    }

    public int getRam()
    {
        return ram;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Manufacturer: {manufacturer}, Storage: {storage}GB, RAM: {ram}GB");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Item myItem = new Item("Trophy", "All Star", 9.99f);
        myItem.Display();

        Book myBook = new Book("C# Programming for Beginners", "ABC Publications", 19.99f, 300, "Programming");
        myBook.Display();

        Magazine myMagazine = new Magazine("PC World", "IDG Communications", 5.99f, "March 2023");
        myMagazine.Display();

        Phone myPhone = new Phone("iPhone 13", "Apple", 999.99f, "Apple Inc.", 256, 8);
        myPhone.Display();
    }
}