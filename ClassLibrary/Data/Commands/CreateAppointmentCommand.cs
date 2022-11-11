using ClassLibrary.Data.Contracts;

namespace ClassLibrary.Data.Commands;
public class CreateAppointmentCommand : Command<CreateAppointmentCommand>
{
    public string? CustomerId { get; set; }
    public string? EmployeeId { get; set; }
    public DateTime Date { get; set; }

    public override Task ExecuteAsync()
    {
        return Receiver is null
            ? Task.CompletedTask
            : Receiver.Invoke(this);
    }
}
