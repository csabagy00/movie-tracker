namespace MovieTracker.Models;

public abstract class Item
{
    public string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public List<string> Genres { get; set; }
    public bool Watched { get; set; }
}