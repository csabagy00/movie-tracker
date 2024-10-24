using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTracker.ViewModels;

public class StatisticsViewModel : ViewModelBase
{
    public ObservableCollection<string> Types { get; set; }

    private string? _selectedType;

    public string SelectedType
    {
        get { return _selectedType; }
        set
        {
            if (value != SelectedType)
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
    }

    public StatisticsViewModel()
    {
        Types = new ObservableCollection<string>{"All", "Movies", "Series"};
    }
}