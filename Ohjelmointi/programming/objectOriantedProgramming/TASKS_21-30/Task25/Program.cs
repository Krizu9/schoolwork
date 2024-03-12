using System;

class Human
{
    public string Name { get; set; }
    public int BirthYear { get; set; }
}

class Actor : Human
{
   
}

class Director : Human
{
    
}

class Movie
{
    public string Name { get; set; }
    public int Year { get; set; }
    public Director Director { get; }
    public IReadOnlyList<Actor> Actors { get; }

    private List<Actor> actors = new List<Actor>();

    public Movie(string name, int year, Director director, IEnumerable<Actor> actors)
    {
        Name = name;
        Year = year;
        Director = director;
        this.actors.AddRange(actors);
        this.Actors = this.actors.AsReadOnly();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        var director = new Director { Name = "Cristopher Nolan", BirthYear = 1970 };
        var actors = new List<Actor> {
            new Actor { 
                Name = "Matthew McConaughey",
                BirthYear = 1969
            },
            new Actor {
                Name = "Jessica Chastain",
                BirthYear = 1977
            }
        };
        var movie = new Movie("Interstellar", 2014, director, actors);

        Console.WriteLine("Movie: " + movie.Name + " Year: " + "(" + movie.Year + ")");
        Console.WriteLine("Director: " + movie.Director.Name + " Born: " + "(" + movie.Director.BirthYear + ")");
        Console.WriteLine("Actors:");
        foreach (var actor in movie.Actors)
        {
            Console.WriteLine("- " + actor.Name + " (" + actor.BirthYear + ")");
        }
        Console.WriteLine();
        var director1 = new Director { Name = "Sylvester Stallone", BirthYear = 1946 };
        var actors1 = new List<Actor>
        {
            new Actor
            {
                Name = "Sylvester Stallone",
                BirthYear= 1946
            }
        };
        var movie1 = new Movie("Rambo: First Blood", 1982, director1, actors1);

        Console.WriteLine("Movie: " + movie1.Name + " Year: " + "(" + movie1.Year + ")");
        Console.WriteLine("Director: " + movie1.Director.Name + " Born: " + "(" + movie1.Director.BirthYear + ")");
        Console.WriteLine("Actors:");
        foreach (var actor in movie1.Actors)
        {
            Console.WriteLine("- " + actor.Name + " (" + actor.BirthYear + ")");
        }

    }
}
