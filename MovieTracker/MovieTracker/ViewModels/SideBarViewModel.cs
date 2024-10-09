using MovieTracker.Commands;
using System.Windows.Input;

namespace MovieTracker.ViewModels;

public class SideBarViewModel : ViewModelBase
{
    private MainViewModel MainViewModel { get; set; }
    public ICommand ShowAddItemCommand { get; set; }

    public SideBarViewModel(MainViewModel mainViewModel)
    {
        MainViewModel = mainViewModel;
        ShowAddItemCommand = new RelayCommand<object>(ShowAddItemView);
    }

    private void ShowAddItemView(object obj)
    {
        MainViewModel.SelectedView = new AddItemViewModel();
    }
}