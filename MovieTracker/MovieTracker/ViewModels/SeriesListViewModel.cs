using Microsoft.EntityFrameworkCore;
using MovieTracker.Commands;
using MovieTracker.Database;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MovieTracker.ViewModels;

public class SeriesListViewModel : ViewModelBase
{
    public ICommand SaveChanges { get; set; }

    private ObservableCollection<SeriesViewModel> _series;
    public ObservableCollection<SeriesViewModel> Series 
    {
        get { return _series; }
        set
        {
            _series = value;
            OnPropertyChanged(nameof(Series));
        }
    }

    public MovieTrackerContext Context { get; set; }

    public SeriesListViewModel(MovieTrackerContext context)
    {
        Context = context;
        SaveChanges = new RelayCommand<object>(ExecuteSaveChanges);
    }

    private void ExecuteSaveChanges(object obj)
    {
        Context.SaveChanges();
    }

    public void GetWatchedSeries(bool watched)
    {
        if(Series == null || Series.Count != Context.Series.Count())
        {
            Series = new ObservableCollection<SeriesViewModel>(
                Context.Series.Where(s => s.Watched == watched)
                .Include(s => s.Genres)
                .ToList()
                .Select(series => new SeriesViewModel(series)));
        }
    }
}