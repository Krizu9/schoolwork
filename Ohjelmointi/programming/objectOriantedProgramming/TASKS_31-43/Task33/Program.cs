using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Friend
{
    public string Name { get; set; }
    public string Email { get; set; }

    public Friend(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

class MailBook
{
    private readonly List<Friend> friends;

    public IReadOnlyList<Friend> Friends => friends;

    public MailBook()
    {
        friends = new List<Friend>();
        LoadFriendsFromFile();
    }

    private void LoadFriendsFromFile()
    {
        try
        {
            using (var reader = new StreamReader("friends.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var friend = new Friend(values[0], values[1]);
                    //friends.csv needs to be in \TASKS_31-43\Task33\bin\Debug\net6.0\friends.csv
                    friends.Add(friend);
                }
            }
            Console.WriteLine($"{friends.Count} names in the address book.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while reading friends from file: {e.Message}");
        }
    }

    public void SearchFriends(string name)
    {
        var matchingFriends = friends.Where(friend => friend.Name.ToLower().Contains(name.ToLower()));
        foreach (var friend in matchingFriends)
        {
            Console.WriteLine($"{friend.Name} {friend.Email}");
        }
    }

    public void AddFriend(string name, string email)
    {
        var friend = new Friend(name, email);
        friends.Add(friend);
        try
        {
            using (var writer = new StreamWriter("friends.csv", true))
            {
                writer.WriteLine($"{name},{email}");
            }
            Console.WriteLine($"{name} added to address book.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while saving friend to file: {e.Message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var mailBook = new MailBook();

        Console.WriteLine("\nAll friends in address book:");
        foreach (var friend in mailBook.Friends)
        {
            Console.WriteLine($"{friend.Name} {friend.Email}");
        }

        Console.Write("\nEnter the name or part of the name of the person you are looking for: ");
        var searchName = Console.ReadLine();
        mailBook.SearchFriends(searchName);

        Console.Write("\nEnter the name of the new friend: ");
        var newFriendName = Console.ReadLine();
        Console.Write("Enter the email of the new friend: ");
        var newFriendEmail = Console.ReadLine();
        mailBook.AddFriend(newFriendName, newFriendEmail);

        Console.WriteLine("\nProgram completed successfully. Press any key to continue...");
        Console.ReadKey();
    }
}
