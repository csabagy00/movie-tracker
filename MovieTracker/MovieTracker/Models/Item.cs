namespace MovieTracker.Models;

public abstract class Item
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Genre> Genres { get; set; }
    public bool Watched { get; set; }
}