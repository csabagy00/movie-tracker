using MovieTracker.Database;
using System.Windows;

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
    public Series(MovieTrackerContext context)
    {
        Genres = new List<Genre>();
        Context = context;
    }
    
    public Series(string title, DateTime release, List<Genre> genres, int totalSeasons, int avgEpLength, bool watched, MovieTrackerContext  context)
    { 
        Title = title;
        ReleaseDate = release;
        Genres = genres;
        TotalSeasons = totalSeasons;
        AvgEpLength = avgEpLength;
        Watched = watched;
        Context = context;
    }

    public bool AddSeriesToDb(object obj)
    {
        if(obj is Series)
        {
            Series series = (Series)obj;
            Context.Series.Add(series);
            Context.SaveChanges();

            MessageBox.Show($"The series {Title} has been added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            return true;
        }
        return false;
    }
}