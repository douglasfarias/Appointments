using ClassLibrary.Data.Commands;
using ClassLibrary.Data.Contracts;
using ClassLibrary.Data.Repositories;
using ClassLibrary.Factories;
using ClassLibrary.Models;

namespace ClassLibrary.Data.Handlers;

public interface IAppointmentsHandler
{
    Task<Appointment> HandleAsync(CreateAppointmentCommand command);
}

public class AppointmentsHandler : Handler, ICommandHandler<CreateAppointmentCommand, Appointment>, IAppointmentsHandler
{
    private readonly IAppointmentsRepository _repository;
    private readonly IAppointmentsFactory _factory;

    public AppointmentsHandler(IAppointmentsRepository repository,
                               IAppointmentsFactory factory)
    {
        _repository = repository;
        _factory = factory;
    }

    public async Task<Appointment> HandleAsync(CreateAppointmentCommand command)
    {
        var appointment = _factory.Create(command);
        await _repository.Add(appointment);
        return appointment;
    }

}
