using MovieTracker.Database;
using MovieTracker.Models;

namespace MovieTracker.ViewModels;

public class MovieStatsViewModel : ViewModelBase
{
    private MovieStatsModel _model;

    public MovieStatsViewModel(MovieTrackerContext context)
    {
        _model = new MovieStatsModel(context);
        _moviesCount = _model.GetWatchedMoviesCount();
        _moviesCountUnwatched = _model.GetUnwatchedMoviesCount();
        _timeSpent = _model.GetTimeSpent();
        _longest = _model.GetLongestMovieTitle();
        _shortest = _model.GetShortestMovieTitle();
        _mostWatchedGenre = _model.GetMostWatchedGenre();
        _completionRate = _model.GetCompletionRate();
    }

    private int _moviesCount;
    public int MoviesCount
    {
        get { return _moviesCount; }
        set
        {
            
        }
    }

    private int _moviesCountUnwatched;
    public int MoviesCountUnwatched
    {
        get { return _moviesCountUnwatched; }
        set
        {

        }
    }

    private int _timeSpent;
    public int TimeSpent
    {
        get { return _timeSpent; }
        set
        {

        }
    }

    private string _longest;
    public string Longest
    {
        get { return _longest; }
        set
        {

        }
    }

    private string _shortest;
    public string Shortest
    {
        get { return _shortest; }
        set
        {

        }
    }

    private string _mostWatchedGenre;
    public string MostWatched
    {
        get { return _mostWatchedGenre; }
        set
        {

        }
    }

    private float _completionRate;
    public float CompletionRate
    {
        get { return _completionRate; }
        set
        {

        }
    }
}

