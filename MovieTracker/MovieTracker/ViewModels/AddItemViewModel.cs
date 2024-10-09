using System.Collections.ObjectModel;

namespace MovieTracker.ViewModels;

public class AddItemViewModel : ViewModelBase
{
    private string? _selectedType;
    public AddMovieViewModel AddMovieViewModel { get; set; }

    public AddItemViewModel()
    {
        ItemTypes = new ObservableCollection<string>{"Movie", "Series"};
        AddMovieViewModel = new AddMovieViewModel();
    }

    public string SelectedType
    {
        get { return _selectedType; }
        set
        {
            if (_selectedType != value)
            {
                _selectedType = value;
                Console.WriteLine($"SelectedType changed to: {_selectedType}");
                OnPropertyChanged(nameof(SelectedType));
            }
        }
    }
    
    public ObservableCollection<string> ItemTypes { get; set; }
}