using System.Windows.Input;

namespace MovieTracker.Commands;

public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;
    
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object? parameter);
}