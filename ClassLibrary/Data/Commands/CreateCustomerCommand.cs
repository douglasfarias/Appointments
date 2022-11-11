using ClassLibrary.Data.Contracts;

namespace ClassLibrary.Data.Commands;
public class CreateCustomerCommand : Command<CreateCustomerCommand>
{
    public string? Name { get; set; }
    public string? GivenName { get; set; }
    public string? SurName { get; set; }

    public override Task ExecuteAsync()
    {
        return Receiver is null
            ? Task.CompletedTask
            : Receiver.Invoke(this);
    }
}
