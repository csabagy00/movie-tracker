using System.Windows.Input;
using MovieTracker.Commands;

namespace MovieTracker.ViewModels;

public class MainViewModel : ViewModelBase
{
    private object _selectedView;
    public object SelectedView
    {
        get { return _selectedView; }
        set
        {
            if (_selectedView != value)
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }
    }
    
    public ICommand ShowAddItemCommand { get; set; }

    public MainViewModel()
    {
        _selectedView = null;
        ShowAddItemCommand = new RelayCommand<object>(ShowAddItemView);
    }

    private void ShowAddItemView(object obj)
    {
        SelectedView = new AddItemViewModel();
    }
}