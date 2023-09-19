using System;

class Song
{
    public string Name { get; set; }
    public TimeSpan Length { get; set; }

    public Song(string name, TimeSpan length)
    {
        Name = name;
        Length = length;
    }
}

class CD
{
    public string Name { get; set; }
    public string Artist { get; set; }
    public List<Song> Songs { get; set; }

    public CD(string name, string artist, List<Song> songs)
    {
        Name = name;
        Artist = artist;
        Songs = songs;
    }

    public int numSongs
    {
        get { return Songs.Count; }
    }

    public TimeSpan totalLength
    {
        get
        {
            TimeSpan total = TimeSpan.Zero;
            foreach (Song song in Songs)
            {
                total += song.Length;
            }
            return total;
        }
    }

    public string getAllInfo()
    {
        string info = $"You have a CD:\n- name: {Name}\n- artist: {Artist}\n- total length: {totalLength.Hours} hr {totalLength.Minutes} min {totalLength.Seconds} sec\n- {numSongs} songs:\n";
        int trackNumber = 1;
        foreach (Song song in Songs)
        {
            info += $"  - {song.Name}, {song.Length:mm\\:ss}\n";
            trackNumber++;
        }
        return info;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Song> songs = new List<Song>
        {
            new Song("Crying in the Rain", TimeSpan.FromSeconds(337)),
            new Song("Bad Boys", TimeSpan.FromSeconds(246)),
            new Song("Still of the Night", TimeSpan.FromSeconds(397)),
            new Song("Here I Go Again", TimeSpan.FromSeconds(275)),
            new Song("Give Me All Your Love", TimeSpan.FromSeconds(208)),
            new Song("Is This Love", TimeSpan.FromSeconds(284)),
            new Song("Children of the Night", TimeSpan.FromSeconds(262)),
            new Song("Straight for the Heart", TimeSpan.FromSeconds(216)),
            new Song("Don't Turn Away", TimeSpan.FromSeconds(306)),
            new Song("Looking for Love", TimeSpan.FromSeconds(391)),
            new Song("You're Gonna Break My Heart Again", TimeSpan.FromSeconds(252))
        };
        CD cd = new CD("Whitesnake", "Whitesnake", songs);
        Console.WriteLine(cd.getAllInfo());
    }
}
