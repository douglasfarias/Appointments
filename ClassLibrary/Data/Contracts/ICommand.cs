namespace ClassLibrary.Data.Contracts;

public interface ICommand
{
    Task ExecuteAsync();
}

public abstract class Command<TCommand> : ICommand where TCommand : ICommand
{
    public Func<TCommand, Task>? Receiver { get; set; }
    public abstract Task ExecuteAsync();
}