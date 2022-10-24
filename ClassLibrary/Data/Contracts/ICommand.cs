namespace ClassLibrary.Data.Contracts;

public interface ICommand
{
    Task ExecuteAsync();
}

public abstract class Command<TCommand> : ICommand where TCommand : ICommand
{
    protected Func<TCommand, Task> Receiver;

    protected Command(Func<TCommand, Task> receiver)
    {
        Receiver = receiver;
    }

    public abstract Task ExecuteAsync();
}