using MovieTracker.Database;
using System.Collections.ObjectModel;

namespace MovieTracker.ViewModels;

public class AddItemViewModel : ViewModelBase
{
    private string? _selectedType;
    public MovieViewModel MovieViewModel { get; set; }
    public SeriesViewModel SeriesViewModel { get; set; }

    public AddItemViewModel(MovieTrackerContext movieTrackerContext)
    {
        ItemTypes = new ObservableCollection<string>{"Movie", "Series"};
        MovieViewModel = new MovieViewModel(movieTrackerContext);
        SeriesViewModel = new SeriesViewModel(movieTrackerContext);
    }

    public string SelectedType
    {
        get { return _selectedType; }
        set
        {
            if (_selectedType != value)
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
    }
    
    public ObservableCollection<string> ItemTypes { get; set; }
}