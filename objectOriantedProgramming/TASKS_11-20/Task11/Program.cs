using System;

class CD
{
    public string Album { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public List<string> Songs { get; set; }

    public CD(string album, string artist, string genre, double price, int year, List<string> songs)
    {
        Album = album;
        Artist = artist;
        Genre = genre;
        Price = price;
        Year = year;
        Songs = songs;
    }

    public string GetAllInfo()
    {
        int trackNumber = 0;
        string info = $" Album: {Album}\n Artist: {Artist}\n Genre: {Genre}\n Year: {Year}\n Price: ${Price}\n Songs: ";
        foreach (string song in Songs)
        {
            trackNumber++;
            info += $"\nTrack: {trackNumber} - {song}";
        }
        return info;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<string> songs = new List<string> { "Crying in the Rain - 5:37", "Bad Boys - 4:06", "Still of the Night - 6:37", "Here I Go Again - 4:35", "Give Me All Your Love - 3:28", "Is This Love - 4:44", "Children of the Night - 4:22", "Straight for the Heart - 3:36", "Don't Turn Away - 5:06", "Looking for Love - 6:31", "You're Gonna Break My Heart Again - 4:12" };
        CD cd = new CD("Whitesnake", "Whitesnake", "Rock", 19.9, 1987, songs);
        Console.WriteLine(cd.GetAllInfo());
    }
}