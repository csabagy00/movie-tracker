using System.Windows.Input;
using MovieTracker.Commands;
using MovieTracker.Database;

namespace MovieTracker.ViewModels;

public class MainViewModel : ViewModelBase
{
    private object? _selectedView;
    public object SelectedView
    {
        get { return _selectedView!; }
        set
        {
            if (_selectedView != value)
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }
    }
    public MovieTrackerContext MovieTrackerContext { get; set; }
    
    public SideBarViewModel SideBarViewModel { get; set; }

    public MainViewModel()
    {
        _selectedView = null;
        MovieTrackerContext = new MovieTrackerContext();
        SideBarViewModel = new SideBarViewModel(this, MovieTrackerContext);
    }
}