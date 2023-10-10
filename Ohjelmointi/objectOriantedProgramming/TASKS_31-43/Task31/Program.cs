using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace random
{
    class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }

    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            listExample();
            dictionaryExample();
        }

        static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void listExample()
        {
            List<Person> peopleList = new List<Person>();
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("List Collection:");
            stopwatch.Start();
            for (int i = 0; i < 10000;)
            {
                string firstName = RandomString(4);
                if (!peopleList.Any(p => p.FirstName == firstName))
                {
                    peopleList.Add(new Person { FirstName = firstName, Surname = RandomString(10) });
                    i++;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"- Adding time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count: {peopleList.Count}");
            Console.WriteLine($"- Random person: {peopleList[random.Next(peopleList.Count)].FirstName} {peopleList[random.Next(peopleList.Count)].Surname}");
            Console.WriteLine();

            Console.WriteLine("Finding persons in collection (by first name):");
            stopwatch.Reset();
            stopwatch.Start();
            int foundCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                string randomFirstName = RandomString(4);
                var foundPerson = peopleList.FirstOrDefault(p => p.FirstName == randomFirstName);
                if (foundPerson != null)
                {
                    Console.WriteLine($"- Found person with {randomFirstName} firstname: {foundPerson.FirstName} {foundPerson.Surname}");
                    foundCount++;
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"- Persons tried to find: 1000");
            Console.WriteLine($"- Total finding time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }

        static void dictionaryExample()
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 10000;)
            {
                string firstName = RandomString(4);
                if (!people.ContainsKey(firstName))
                {
                    people.Add(firstName, new Person { FirstName = firstName, Surname = RandomString(10) });
                    i++;
                }
            }

            watch.Stop();

            Console.WriteLine("Dictionary Collection:");
            Console.WriteLine($"- Adding time : {watch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count : {people.Count}");
            Console.WriteLine($"- Random person : {people.ElementAt(random.Next(people.Count)).Value.FirstName} {people.ElementAt(random.Next(people.Count)).Value.Surname}\n");

            watch.Restart();

            Console.WriteLine("Finding persons in collection (by first name):");
            int foundCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                string firstName = RandomString(4);
                if (people.TryGetValue(firstName, out Person person))
                {
                    Console.WriteLine($"- Found person with {firstName} firstname : {person.FirstName} {person.Surname}");
                    foundCount++;
                }
            }
            watch.Stop();

            Console.WriteLine($"- Persons tried to find : {1000}");
            Console.WriteLine($"- Total finding time: {watch.ElapsedMilliseconds} ms\n");
            /*
            On my pc, list collection adding time was 757 ms and dictionary collection adding time was 7 ms. Total finding time of 1000 random persons on list collection was 122 ms and on
            dictionary collection time was 0 ms.
            I am amazed there is that big of a difference between two different ways to store and search data.
            I googled for the reason for this, and found that dictionary uses hash table to look up values in constant time.
            For example, the LINQ extension helps alot with its methods to handle data with lists and dictionaries.
            I used also the ElementAt to find value for specific key, being the name from dictionary.
            Dictionaries in C# has built in method: TryGetValue, that does the same than FirstorDefault for lists.
            ContainsKey() is useful when checking if dictionary has a specific key already. LINQ offers Any() to do the same for list, but you need to specify what we are comparing, and I had
            problems with it.
            */
        }
    }
}