using MovieTracker.Database;
using MovieTracker.Models;

namespace MovieTracker.ViewModels;

public class MovieStatsViewModel : ViewModelBase
{
    private readonly MovieStatsModel _model;

    public MovieStatsViewModel(MovieTrackerContext context)
    {
        _model = new MovieStatsModel(context);
        RefreshMovieStats();
    }

    public void RefreshMovieStats()
    {
        MoviesCount = _model.GetWatchedMoviesCount();
        MoviesCountUnwatched = _model.GetUnwatchedMoviesCount();
        TimeSpent = _model.GetTimeSpent();
        Longest = _model.GetLongestMovieTitle();
        Shortest = _model.GetShortestMovieTitle();
        MostWatchedGenre = _model.GetMostWatchedGenre();
        CompletionRate = _model.GetCompletionRate();
    }

    private int _moviesCount;
    public int MoviesCount
    {
        get => _moviesCount; 
        set
        {
            _moviesCount = value;
            OnPropertyChanged();
        }
    }

    private int _moviesCountUnwatched;
    public int MoviesCountUnwatched
    {
        get => _moviesCountUnwatched; 
        set
        {
            _moviesCountUnwatched = value;
            OnPropertyChanged();
        }
    }

    private int _timeSpent;
    public int TimeSpent
    {
        get => _timeSpent;
        set
        {
            _timeSpent = value;
            OnPropertyChanged();
        }
    }

    private string _longest = "";
    public string Longest
    {
        get => _longest;
        set
        {
            _longest = value;
            OnPropertyChanged();
        }
    }

    private string _shortest = "";
    public string Shortest
    {
        get => _shortest;
        set
        {
            _shortest = value;
            OnPropertyChanged();
        }
    }

    private string _mostWatchedGenre = "";
    public string MostWatchedGenre
    {
        get => _mostWatchedGenre;
        set
        {
            _mostWatchedGenre = value;
            OnPropertyChanged();
        }
    }

    private float _completionRate;
    public float CompletionRate
    {
        get => _completionRate; 
        set
        {
            _completionRate = value;
            OnPropertyChanged();
        }
    }
}

