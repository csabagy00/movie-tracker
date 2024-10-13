namespace MovieTracker.Models;

public class Series : Item
{
    public int Id { get; set; }
    public int TotalSeasons { get; set; }
    public int AvgEpLength { get; set; }

    public MovieTrackerContext Context { get; set; }

    public string DisplayGenres
    {
        get
        {
            if (Genres.Count == 1)
                return Genres[0].Name;

            if (Genres.Count == 0 || Genres == null)
                return "N/A";

            return string.Join(", ", Genres.Select(gen => gen.Name));
        }
    }
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