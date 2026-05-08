using MovieTracker.Database;
using MovieTracker.Enums;
using System.Collections.ObjectModel;

namespace MovieTracker.ViewModels;

public class StatisticsViewModel : ViewModelBase
{
    public ObservableCollection<StatType> Types { get; set; }

    private StatType _selectedType;

    public MovieStatsViewModel MovieStatsViewModel { get; set; }
    public SeriesStatsViewModel SeriesStatsViewModel { get; set; }

    public StatType SelectedType
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

    public StatisticsViewModel(MovieTrackerContext context)
    {
        Types = new ObservableCollection<StatType>(Enum.GetValues<StatType>());
        MovieStatsViewModel = new MovieStatsViewModel(context);
        SeriesStatsViewModel = new SeriesStatsViewModel(context);
    }
}