using ClassLibrary.Data.Commands;
using ClassLibrary.Models;

namespace ClassLibrary.Factories;

public interface IAppointmentsFactory
{
    Appointment Create(CreateAppointmentCommand command);
}

public class AppointmentsFactory : IAppointmentsFactory
{
    public Appointment Create(CreateAppointmentCommand command)
    {
        var appointment = new Appointment();
        appointment.Employee = UserFactory.CreateEmployee(command.EmployeeId!, string.Empty, string.Empty);
        appointment.Customer = UserFactory.CreateCustomer(command.CustomerId!, string.Empty, string.Empty);
        appointment.Date = command.Date;
        return appointment;
    }
}
