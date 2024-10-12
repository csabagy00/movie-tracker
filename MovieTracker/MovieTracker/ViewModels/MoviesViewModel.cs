using Microsoft.EntityFrameworkCore;
using MovieTracker.Commands;
using MovieTracker.Database;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieTracker.ViewModels;

public class MoviesViewModel : ViewModelBase
{
    public ICommand SaveChanges { get; set; }

    private ObservableCollection<MovieViewModel> _movies;
    public ObservableCollection<MovieViewModel> Movies 
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
        SaveChanges = new RelayCommand<object>(ExecuteSaveChanges);
        GetWatchedMovies(true);
    }

    private void ExecuteSaveChanges(object obj)
    {
        Context.SaveChanges();
    }

    public void GetWatchedMovies(bool watched)
    {
        if(Movies == null || Movies.Count() != Context.Movies.Count())
        {
            Movies = new ObservableCollection<MovieViewModel>(
                Context.Movies.Where(m => m.Watched == watched)
                .Include(m => m.Genres)
                .ToList()
                .Select(movie => new MovieViewModel(movie)));
        }
    }
}

