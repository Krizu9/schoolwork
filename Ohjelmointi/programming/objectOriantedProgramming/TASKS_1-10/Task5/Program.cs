using System;

struct Person
{
    public string Name;
    public int YearOfBirth;
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        Console.WriteLine("Please, give names and birth year of a person. Empty input will stop the input.");

        while (true)
        {
            
            Console.Write("Give a name: ");
            string input = Console.ReadLine();

            if (input == "")
                break;

            string[] parts = input.Split(',');
            string name = parts[0].Trim();
            int yearOfBirth = int.Parse(parts[1].Trim());

            people.Add(new Person { Name = name, YearOfBirth = yearOfBirth });
        }


        Console.WriteLine();
        Console.WriteLine(people.Count + " names are given:");

        people.Sort((a, b) => (2023 - a.YearOfBirth) - (2023 - b.YearOfBirth));

        foreach (Person person in people)
        {
            Console.WriteLine((person.Name) + " is " + (2023 - person.YearOfBirth) + " years old");
        }
    }
}