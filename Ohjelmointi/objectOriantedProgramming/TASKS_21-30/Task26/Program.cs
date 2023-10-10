using System;

class Player
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string gameLocation { get; set; }
    public int Number { get; set; }
}

class Team
{
    public string Name { get; }
    public string Hometown { get; }
    public List<Player> Players { get; } = new List<Player>();

    public Team(string name)
    {
        Name = name;

        switch (name.ToLower())
        {
            case "jyp":
                Hometown = "Jyväskylä";
                Players.AddRange(new[] 
                {
                    new Player { firstName = "Ossi", lastName = "Louhivaara", gameLocation = "Hyökkäys", Number = 11 },
                    new Player { firstName = "Juha-Pekka", lastName = "Hytönen", gameLocation = "Hyökkäys", Number = 21 },
                    new Player { firstName = "Mikko", lastName = "Kalteva", gameLocation = "Puolustus", Number = 27 },
                    new Player { firstName = "Janne", lastName = "Jokinen", gameLocation = "Maalivahti", Number = 35 }
                });
                break;
            case "ilves":
                Hometown = "Tampere";
                Players.AddRange(new[] {
                    new Player { firstName = "Eemeli", lastName = "Suomi", gameLocation = "Hyökkäys", Number = 9 },
                    new Player { firstName = "Teemu", lastName = "Lepaus", gameLocation = "Hyökkäys", Number = 15 },
                    new Player { firstName = "Santeri", lastName = "Airola", gameLocation = "Puolustus", Number = 5 },
                    new Player { firstName = "Lassi", lastName = "Lehtinen", gameLocation = "Maalivahti", Number = 31 }
                });
                break;
            case "tappara":
                Hometown = "Jyväskylä";
                Players.AddRange(new[]
                {
                    new Player { firstName = "Vilho", lastName = "Heikkinen", gameLocation = "Maalivahti", Number = 1 },
                    new Player { firstName = "Ben", lastName = "Thomas", gameLocation = "Puolustus", Number = 4 },
                    new Player { firstName = "Mikael", lastName = "Seppälä", gameLocation = "Puolustus", Number = 5 },
                    new Player { firstName = "Waltteri", lastName = "Merelä", gameLocation = "Hyökkäys", Number = 9 }
                });
                break;
            case "pelicans":
                Hometown = "Lahti";
                Players.AddRange(new[]
                {
                    new Player { firstName = "Oskari", lastName = "Parviainen", gameLocation = "Maalivahti", Number = 41 },
                    new Player { firstName = "Toni", lastName = "Utunen", gameLocation = "Puolustus", Number = 3 },
                    new Player { firstName = "Ben", lastName = "Blood", gameLocation = "Puolustus", Number = 10 },
                    new Player { firstName = "Lars", lastName = "Byggman", gameLocation = "Hyökkäys", Number = 2 }
                });
                break;
            default:
                  Console.WriteLine("Invalid team name");
                break;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var teams = new List<Team>();

        while (true)
        {
            Console.WriteLine("Input 1 to Add team");
            Console.WriteLine("Input 2 to Delete team");
            Console.WriteLine("Input 3 to List teams");
            Console.Write("Choose option: ");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Enter team name: ");
                    var teamName = Console.ReadLine();
                    if (string.IsNullOrEmpty(teamName))
                    {
                        Console.WriteLine("\nInvalid team name\n");
                        break;
                    }
                    var existingTeam = teams.Find(t => t.Name.ToLower() == teamName.ToLower());
                    if (existingTeam != null)
                    {
                        Console.WriteLine("\nTeam already exists\n");
                    }
                    else
                    {
                        var team = new Team(teamName.ToLower());
                        teams.Add(team);
                        Console.WriteLine("\nTeam added\n");
                    }
                    break;

                case 2:
                    Console.Write("\nEnter team name: ");
                    var nameToDelete = Console.ReadLine();
                    if (string.IsNullOrEmpty(nameToDelete))
                    {
                        Console.WriteLine("\nInvalid team name\n");
                        break;
                    }
                    var teamToDelete = teams.Find(t => t.Name.ToLower() == nameToDelete.ToLower());
                    if (teamToDelete != null)
                    {
                        teams.Remove(teamToDelete);
                        Console.WriteLine("\nTeam deleted\n");
                    }
                    else
                    {
                        Console.WriteLine("\nTeam not found\n");
                    }
                    break;


                case 3:
                    Console.WriteLine("\nTeams:");
                    foreach (var Team in teams)
                    {
                        Console.WriteLine("{0} ({1}):", Team.Name, Team.Hometown);
                        foreach (var player in Team.Players)
                        {
                            Console.WriteLine("{0} {1} #{2}\n{3}\n", player.firstName, player.lastName, player.Number, player.gameLocation);
                        }
                    }
                    break;

                default:
                    Console.WriteLine("\nInvalid option\n");
                    break;
            }
        }
    }
}
