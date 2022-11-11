using ClassLibrary.Data.Commands;

namespace ClassLibrary.Factories;
public class CommandFactory
{
    public static CreateAppointmentCommand CreateAppointmentCommand(Func<CreateAppointmentCommand, Task>? receiver)
    {
        var command = new CreateAppointmentCommand();
        command.Date = DateTime.Now;
        command.Receiver = receiver;
        return command;
    }
}
