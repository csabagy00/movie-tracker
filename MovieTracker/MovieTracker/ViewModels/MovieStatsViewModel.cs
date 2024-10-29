using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.ViewModels;

public class MovieStatsViewModel : ViewModelBase
{
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

