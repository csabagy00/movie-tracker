using MovieTracker.Commands;
using MovieTracker.Database;
using System.Windows.Input;

namespace MovieTracker.ViewModels;

public class SideBarViewModel : ViewModelBase
{
    private MainViewModel MainViewModel { get; set; }
    private AddItemViewModel AddItemViewModel { get; set; }
    private MoviesViewModel MoviesViewModel { get; set; }
    public ICommand ShowAddItemCommand { get; set; }
    public ICommand ShowMoviesCommand { get; set; }
    public ICommand ShowUnwatchedMoviesCommand { get; set; }

    public SideBarViewModel(MainViewModel mainViewModel, MovieTrackerContext movieTrackerContext)
    {
        MainViewModel = mainViewModel;
        ShowAddItemCommand = new RelayCommand<object>(ShowAddItemView);
        ShowMoviesCommand = new RelayCommand<object>(ShowMoviesView);
        ShowUnwatchedMoviesCommand = new RelayCommand<object>(ShowUnwatchedMoviesView);

        AddItemViewModel = new AddItemViewModel(movieTrackerContext);
        MoviesViewModel = new MoviesViewModel(movieTrackerContext);
    }

    private void ShowAddItemView(object obj)
    {

        MainViewModel.SelectedView = AddItemViewModel;
    }

    private void ShowMoviesView(object obj) 
    {
        MoviesViewModel.GetWatchedMovies(true);
        MainViewModel.SelectedView = MoviesViewModel;
    }

    private void ShowUnwatchedMoviesView(object obj)
    {
        MoviesViewModel.GetWatchedMovies(false);
        MainViewModel.SelectedView = MoviesViewModel;
    }
}