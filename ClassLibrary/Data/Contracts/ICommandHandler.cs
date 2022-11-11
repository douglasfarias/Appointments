namespace ClassLibrary.Data.Contracts;
public interface ICommandHandler<TCommand> : IHandler where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}

public interface ICommandHandler<TCommand, TResult> : IHandler where TCommand : ICommand
{
    Task<TResult> HandleAsync(TCommand command);
}