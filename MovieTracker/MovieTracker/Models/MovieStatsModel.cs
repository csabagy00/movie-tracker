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
        return _context.Movies.Where(m => m.Watched == true).Count();
    }
}

