using Microsoft.EntityFrameworkCore;
using MovieTracker.Database;
using MovieTracker.Models;
using System.Collections.ObjectModel;

namespace MovieTracker.ViewModels;

public class MoviesViewModel : ViewModelBase
{
    private ObservableCollection<Movie> _movies;
    public ObservableCollection<Movie> Movies 
    { 
        get { return _movies; } 
        set {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            } 
    }
    public MovieTrackerContext Context { get; set; }

    public MoviesViewModel(MovieTrackerContext context)
    {
        Context = context;
        GetWatchedMovies();

    }

    public void GetWatchedMovies()
    {
        if(Movies == null || Movies.Count() != Context.Movies.Count())
        {
            Movies = new ObservableCollection<Movie>(Context.Movies.Where(m => m.Watched == true).Include(m => m.Genres).ToList());
        }
    }
}

