namespace MovieTracker.Models;

public class Movie : Item
{
    public int Id { get; set; }
    
    public int Length { get; set; }

    public Movie()
    {
    }
    
    public Movie(string title, DateTime releaseDate, List<Genre> genres, int length, bool watched)
    {
        Title = title;
        ReleaseDate = releaseDate;
        Genres = genres;
        Length = length;
        Watched = watched;
    }
}