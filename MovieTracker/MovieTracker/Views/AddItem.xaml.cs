using System.Windows.Controls;
using MovieTracker.ViewModels;

namespace MovieTracker.Views;

public partial class AddItem : UserControl
{
    public AddItem()
    {
        InitializeComponent();
        DataContext = new AddItemViewModel();
    }
}