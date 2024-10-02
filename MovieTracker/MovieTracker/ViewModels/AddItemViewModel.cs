namespace MovieTracker.ViewModels;

public class AddItemViewModel : ViewModelBase
{
    private string _selectedType;

    public AddItemViewModel()
    {
        _selectedType = "Movie";
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
}