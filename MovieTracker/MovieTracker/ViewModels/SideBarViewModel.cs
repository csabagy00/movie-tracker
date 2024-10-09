using MovieTracker.Commands;
using MovieTracker.Database;
using System.Windows.Input;

namespace MovieTracker.ViewModels;

public class SideBarViewModel : ViewModelBase
{
    private MainViewModel MainViewModel { get; set; }
    private AddItemViewModel AddItemViewModel { get; set; }
    public ICommand ShowAddItemCommand { get; set; }

    public SideBarViewModel(MainViewModel mainViewModel, MovieTrackerContext movieTrackerContext)
    {
        MainViewModel = mainViewModel;
        ShowAddItemCommand = new RelayCommand<object>(ShowAddItemView);
        AddItemViewModel = new AddItemViewModel(movieTrackerContext);
    }

    private void ShowAddItemView(object obj)
    {
        
        MainViewModel.SelectedView = AddItemViewModel;
    }
}