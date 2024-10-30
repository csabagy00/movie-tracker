using MovieTracker.Database;
using MovieTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.ViewModels;

public class SeriesStatsViewModel
{
    public SeriesStatsModel seriesStatsModel { get; set; }

    public SeriesStatsViewModel(MovieTrackerContext context)
    {
        seriesStatsModel = new SeriesStatsModel(context);
        RefreshSeriesStats();
    }

    private void RefreshSeriesStats()
    {
        _seriesCount = seriesStatsModel.GetWatchedSeriesCount();
        _seriesCountUnwatched = seriesStatsModel.GetUnwatchedSeriesCount();
        _timeSpent = seriesStatsModel.GetTimeSpent();
        _longest = seriesStatsModel.GetLongestSeriesTitle();
        _shortest = seriesStatsModel.GetShortestSeriesTitle();
        _mostLikedGenre = seriesStatsModel.GetMostLikedGenre();
        _completionRate = seriesStatsModel.GetCompletionRate();
    }

    private int _seriesCount;
    public int SeriesCount
    {
        get { return _seriesCount; }
        set
        {

        }
    }

    private int _seriesCountUnwatched;
    public int SeriesCountUnwatched
    {
        get { return _seriesCountUnwatched; }
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

    private string _mostLikedGenre;
    public string MostLikedGenre
    {
        get { return _mostLikedGenre; }
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
