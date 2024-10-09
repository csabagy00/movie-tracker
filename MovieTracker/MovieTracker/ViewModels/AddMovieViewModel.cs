using MovieTracker.Models;

namespace MovieTracker.ViewModels;

public class AddMovieViewModel : ViewModelBase
{
    private string _title;
    public string Title
    {
        get { return _title; }
        set
        {
            if (_title != value)
            {
                _title = value;
                Console.WriteLine(_title);
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    private DateTime _releaseDate;
    public DateTime ReleaseDate
    {
        get { return _releaseDate; }
        set
        {
            if (_releaseDate != value)
            {
                _releaseDate = value;
                Console.WriteLine(_releaseDate);
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
    }

    private string _genreOne;
    public string GenreOne
    {
        get { return _genreOne; }
        set
        {
            if (GenreOne != value)
            {
                _genreOne = value;
                OnPropertyChanged(nameof(GenreOne));
            }
        }
    }
    
    private string? _genreTwo;
    public string GenreTwo
    {
        get { return _genreTwo; }
        set
        {
            if (GenreTwo != value)
            {
                _genreTwo = value;
                OnPropertyChanged(nameof(GenreTwo));
            }
        }
    }
    
    private string? _genreThree;
    public string GenreThree
    {
        get { return _genreThree; }
        set
        {
            if (GenreThree != value)
            {
                _genreThree = value;
                OnPropertyChanged(nameof(GenreThree));
            }
        }
    }

    private int _length;
    public int Length
    {
        get { return _length; }
        set
        {
            if (Length != value)
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }
    }

    private bool _watched;
    public bool Watched
    {
        get { return _watched; }
        set
        {
            if (Watched != value)
            {
                _watched = value;
                OnPropertyChanged(nameof(Watched));
            }
        }
    }
}