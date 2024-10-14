using MovieTracker.Commands;
using MovieTracker.Database;
using MovieTracker.Models;
using System.Linq;
using System.Windows.Input;

namespace MovieTracker.ViewModels;

public class MovieViewModel : ViewModelBase
{
    public ICommand AddMovieCommand { get; set; }
    private Movie Movie { get; set; }

    public MovieViewModel(MovieTrackerContext movieTrackerContext)
    {
        Movie = new Movie(movieTrackerContext);
        AddMovieCommand = new RelayCommand<object>(ExecuteAddMovieCommand);
    }

    public MovieViewModel(Movie movie)
    {
        Movie = movie;
    }

    public void ExecuteAddMovieCommand(object parameter)
    {
        Movie.AddMovieToDb(Movie);
    }

    public string Title
    {
        get { return Movie.Title; }
        set
        {
            if (Title != value)
            {
                Movie.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }

    public DateTime ReleaseDate
    {
        get { return Movie.ReleaseDate; }
        set
        {
            if (ReleaseDate != value)
            {
                Movie.ReleaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }
    }

    public string DisplayGenres
    {
        get
        {
            if (Movie.Genres.Count == 1)
                return Movie.Genres[0].Name;

            if (Movie.Genres.Count == 0 || Movie.Genres == null)
                return "N/A";

            return string.Join(", ", Movie.Genres.Select(g => g.Name));
        }
    }

    private string _genreOne;
    public string GenreOne
    {
        get { return _genreOne; }
        set
        {
            if(_genreOne is not null)
            {
                Genre? selected = Movie.Genres.FirstOrDefault(gen => gen.Name == _genreOne);

                if (selected != null && Movie.Genres.Contains(selected))
                {
                    Movie.Genres.Remove(selected);
                }
            }
            

            if (GenreOne != value)
            {
                _genreOne = value;
                OnPropertyChanged(nameof(GenreOne));

                if(GenreOne != null)
                {
                    Genre genre = new Genre(_genreOne);
                    Movie.Genres.Add(genre);
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
            if(_genreTwo is not null)
            {
                Genre? selected = Movie.Genres.FirstOrDefault(gen => gen.Name == _genreTwo);

                if(selected != null && Movie.Genres.Contains(selected))
                {
                    Movie.Genres.Remove(selected);
                }
            }

            if (GenreTwo != value)
            {
                _genreTwo = value;
                OnPropertyChanged(nameof(GenreTwo));

                if(GenreTwo != null)
                {
                    Genre genre = new Genre(_genreTwo);
                    Movie.Genres.Add(genre);
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
            if(_genreThree is not null)
            {
                Genre? selected = Movie.Genres.FirstOrDefault(gen => gen.Name == _genreThree);

                if(selected != null && Movie.Genres.Contains(selected))
                {
                    Movie.Genres.Remove(selected);
                }
            }

            if (GenreThree != value)
            {
                _genreThree = value;
                OnPropertyChanged(nameof(GenreThree));

                if(GenreThree != null)
                {
                    Genre genre = new Genre(_genreThree);
                    Movie.Genres.Add(genre);
                }
            }
        }
    }

    public int Length
    {
        get { return Movie.Length; }
        set
        {
            if (Length != value)
            {
                Movie.Length = value;
                OnPropertyChanged(nameof(Length));
            }
        }
    }

    public bool Watched
    {
        get { return Movie.Watched; }
        set
        {
            if (Watched != value)
            {
                Movie.Watched = value;
                OnPropertyChanged(nameof(Watched));
            }
        }
    }
}