namespace MovieTracker.Models;

public class Movie : Item
{
    public int Length { get; }

    public Movie(string title, DateOnly release, List<string> genres, int length, bool watched)
    {
        Title = title;
        ReleaseDate = release;
        Genres = genres;
        Length = length;
        Watched = watched;
    }
}