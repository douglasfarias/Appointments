namespace ClassLibrary.Data.Contracts;
internal interface ICommandHandler<TCommand> : IHandler where TCommand : ICommand
{
    Task Handle(TCommand command);
}
