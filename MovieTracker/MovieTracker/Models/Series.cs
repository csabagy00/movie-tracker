namespace MovieTracker.Models;

public class Series : Item
{
    public List<Season> TotalSeasons { get; }
    public int AvgEpLength { get; }

    public Series(string title, DateOnly release, List<string> genres, List<Season> totalSeasons, int avgEpLength, bool watched)
    { 
        Title = title;
        ReleaseDate = release;
        Genres = genres;
        TotalSeasons = totalSeasons;
        AvgEpLength = avgEpLength;
        Watched = watched;
    }
}