using ClassLibrary.Data.Contracts;

namespace ClassLibrary.Data.Commands;
public class CreateCustomerCommand : Command<CreateCustomerCommand>, ICommand
{
    public CreateCustomerCommand(string name, string displayName, Func<CreateCustomerCommand, Task> receiver) : base(receiver)
    {
        Name = name;
        DisplayName = displayName;
    }

    public string Name { get; set; }
    public string DisplayName { get; set; }

    public override Task ExecuteAsync()
    {
        return Receiver.Invoke(this);
    }
}
