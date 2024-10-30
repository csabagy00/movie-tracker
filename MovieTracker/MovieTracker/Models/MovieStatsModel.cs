using Microsoft.EntityFrameworkCore;
using MovieTracker.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MovieTracker.Models;

public class MovieStatsModel
{
    private MovieTrackerContext _context;

    public MovieStatsModel(MovieTrackerContext context)
    {
        _context = context;
    }

    public int GetWatchedMoviesCount()
    {
        return _context.Movies
            .Where(m => m.Watched == true)
            .Count();
    }

    public int GetUnwatchedMoviesCount()
    {
        return _context.Movies
            .Where(m => m.Watched == false)
            .Count();
    }

    public int GetTimeSpent()
    {
        return _context.Movies
            .Where(m => m.Watched == true)
            .Select(m => m.Length)
            .Sum();
    }

    public string GetLongestMovieTitle()
    {
        int max;

        max = _context.Movies
            .Where(m => m.Watched == true)
            .Select(m => m.Length)
            .Max();

        return _context.Movies
            .Where(m => m.Watched == true && m.Length == max)
            .First().Title; ;
    }

    public string GetShortestMovieTitle()
    {
        int min;

        min = _context.Movies
            .Where(m => m.Watched == true)
            .Select(m => m.Length)
            .Min();

        return _context.Movies
            .Where(m => m.Watched == true && m.Length == min)
            .First().Title;
    }

    public string GetMostWatchedGenre()
    {
        string test = _context.Genres
            .Where(g => EF.Property<int?>(g, "MovieId") != null)
            .GroupBy(g => g.Name)
            .OrderByDescending(g => g.Count())
            .Select(g => g.First())
            .First().Name;

        return test != null ? test : "No genre";
    }

    public float GetCompletionRate()
    {
        float allMovies = _context.Movies.Count();
        float watched = _context.Movies.Where(m => m.Watched == true).Count();

        return (watched / allMovies) * 100;
    }
}

