using MovieTracker.Database;

namespace MovieTracker.Models;

public class Movie : Item
{
    public int Id { get; set; }
    
    public int Length { get; set; }
    public MovieTrackerContext Context { get; set; }

    public Movie(MovieTrackerContext movieTrackerContext)
    {
        Genres = new List<Genre>();
        Context = movieTrackerContext;
    }
    
    public Movie(string title, DateTime releaseDate, List<Genre> genres, int length, bool watched, MovieTrackerContext movieTrackerContext)
    {
        Title = title;
        ReleaseDate = releaseDate;
        Genres = genres;
        Length = length;
        Watched = watched;
        Context = movieTrackerContext;
    }

    public void AddMovieToDb(object obj)
    {
        if (obj is Movie) 
        {
            Movie movie = (Movie)obj;
            Context.Movies.Add(movie);
            Context.SaveChanges();
        }
    }
}