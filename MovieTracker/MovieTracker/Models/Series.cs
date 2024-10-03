namespace MovieTracker.Models;

public class Series : Item
{
    public int Id { get; set; }
    public int TotalSeasons { get; set; }
    public int AvgEpLength { get; set; }

    public Series()
    {
    }
    
    public Series(string title, DateTime release, List<Genre> genres, int totalSeasons, int avgEpLength, bool watched)
    { 
        Title = title;
        ReleaseDate = release;
        Genres = genres;
        TotalSeasons = totalSeasons;
        AvgEpLength = avgEpLength;
        Watched = watched;
    }
}