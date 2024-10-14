using MovieTracker.Commands;
using MovieTracker.Database;
using MovieTracker.Models;
using System.Windows.Input;

namespace MovieTracker.ViewModels;

public class SeriesViewModel : ViewModelBase
{
    public ICommand AddSeriesCommand { get; set; }
    private Series _series;

    public SeriesViewModel(MovieTrackerContext movieTrackerContext)
    {
        _series = new Series(movieTrackerContext);
        AddSeriesCommand = new RelayCommand<object>(ExecuteAddSeriesCommand);
    }

    public SeriesViewModel(Series series)
    {
        _series = series;
    }

    private void ExecuteAddSeriesCommand(object obj)
    {
        _series.AddSeriesToDb(_series);
        Title = "";
        ReleaseDate = new DateTime();
        GenreOne = "";
        GenreTwo = "";
        GenreThree = "";
        TotalSeasons = 0;
        AvgEpLength = 0;
        Watched = false;
    }

    public string Title
    {
        get { return _series.Title; }
        set
        {
            if (_series.Title != value)
            {
                _series.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public DateTime ReleaseDate
    {
        get { return _series.ReleaseDate; }
        set
        {
            if (_series.ReleaseDate != value)
            {
                _series.ReleaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
    }

    public string DisplayGenres
    {
        get
        {
            if (_series.Genres.Count == 1)
                return _series.Genres[0].Name;

            if (_series.Genres.Count == 0 || _series.Genres == null)
                return "N/A";

            return string.Join(", ", _series.Genres.Select(g => g.Name));
        }
    }

    private string _genreOne;
    public string GenreOne
    {
        get { return _genreOne; }
        set
        {
            if (_genreOne is not null)
            {
                Genre? selected = _series.Genres.FirstOrDefault(gen => gen.Name == _genreOne);

                if (selected != null && _series.Genres.Contains(selected))
                {
                    _series.Genres.Remove(selected);
                }
            }

            if (GenreOne != value)
            {
                _genreOne = value;
                OnPropertyChanged(nameof(GenreOne));

                if (GenreOne != null)
                {
                    Genre genre = new Genre(_genreOne);
                    _series.Genres.Add(genre);
                }
            }
        }
    }

    private string? _genreTwo;
    public string GenreTwo
    {
        get { return _genreTwo == null ? "" : _genreTwo; }
        set
        {
            if (_genreTwo is not null)
            {
                Genre? selected = _series.Genres.FirstOrDefault(gen => gen.Name == _genreTwo);

                if (selected != null && _series.Genres.Contains(selected))
                {
                    _series.Genres.Remove(selected);
                }
            }

            if (GenreTwo != value)
            {
                _genreTwo = value;
                OnPropertyChanged(nameof(GenreTwo));

                if (GenreTwo != null)
                {
                    Genre genre = new Genre(_genreTwo);
                    _series.Genres.Add(genre);
                }
            }
        }
    }

    private string? _genreThree;
    public string GenreThree
    {
        get { return _genreThree == null ? "" : _genreThree; }
        set
        {
            if (_genreThree is not null)
            {
                Genre? selected = _series.Genres.FirstOrDefault(gen => gen.Name == _genreThree);

                if (selected != null && _series.Genres.Contains(selected))
                {
                    _series.Genres.Remove(selected);
                }
            }

            if (GenreThree != value)
            {
                _genreThree = value;
                OnPropertyChanged(nameof(GenreThree));

                if (GenreThree != null)
                {
                    Genre genre = new Genre(_genreThree);
                    _series.Genres.Add(genre);
                }
            }
        }
    }

    public int TotalSeasons
    {
        get { return _series.TotalSeasons; }
        set
        {
            if(_series.TotalSeasons != value)
            {
                _series.TotalSeasons = value;
                OnPropertyChanged(nameof(TotalSeasons));
            }
        }
    }

    public int AvgEpLength
    {
        get { return _series.AvgEpLength; }
        set
        {
            if(_series.AvgEpLength != value)
            {
                _series.AvgEpLength = value;
                OnPropertyChanged(nameof(AvgEpLength));
            }
        }
    }

    public bool Watched
    {
        get { return _series.Watched; }
        set
        {
            if(_series.Watched != value)
            {
                _series.Watched = value;
                OnPropertyChanged(nameof(Watched));
            }
        }
    }
}

