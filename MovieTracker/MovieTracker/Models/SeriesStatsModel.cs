using Microsoft.EntityFrameworkCore;
using MovieTracker.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.Models;

public class SeriesStatsModel
{
    private MovieTrackerContext _context;

    public SeriesStatsModel(MovieTrackerContext context)
    {
        _context = context;
    }

    public int GetWatchedSeriesCount()
    {
        return _context.Series
            .Where(s => s.Watched == true)
            .Count();
    }

    public int GetUnwatchedSeriesCount()
    {
        return _context.Series
            .Where(s => s.Watched == false)
            .Count();
    }

    public int GetTimeSpent()
    {
        //Need to modify Series model to have a episodes/season (avg if ep count differs in different seasons)
        return 0;
    }

    public string GetLongestSeriesTitle()
    {
        var groupedSeries = _context.Series
            .Where(s => s.Watched == true)
            .AsEnumerable()
            .GroupBy(s => s.TotalSeasons)
            .OrderByDescending(s => s.Count()).First();

        return groupedSeries
            .GroupBy(s => s.AvgEpLength)
            .OrderByDescending(s => s.Count())
            .Select(s => s.First())
            .First().Title;
    }

    public string GetShortestSeriesTitle()
    {
        var groupedSeries = _context.Series
            .Where(s => s.Watched == true)
            .AsEnumerable()
            .GroupBy(s => s.TotalSeasons)
            .OrderByDescending(s => s.Count()).Last();

        return groupedSeries
            .GroupBy(s => s.AvgEpLength)
            .OrderByDescending(s => s.Count())
            .Select(s => s.Last())
            .Last().Title;
    }

    public string GetMostLikedGenre()
    {
        string genre = _context.Genres
            .Where(s => EF.Property<int?>(s, "SeriesId") != null)
            .GroupBy(s => s.Name)
            .OrderByDescending(s => s.Count())
            .Select(s => s.First())
            .First().Name;

        return genre != null ? genre : "No genre";
    }

    public float GetCompletionRate()
    {
        float allSeriesCount = _context.Series.Count();
        float watchedSeriesCount = _context.Series.Where(s => s.Watched == true).Count();

        return (watchedSeriesCount / allSeriesCount) * 100;
    }
}
