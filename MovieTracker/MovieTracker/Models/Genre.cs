namespace MovieTracker.Models;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Genre(string name)
    {
        Name = name;
    }
}