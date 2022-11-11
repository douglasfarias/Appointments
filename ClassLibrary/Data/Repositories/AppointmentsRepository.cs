using ClassLibrary.Models;

using Dapper;

using System.Data;

namespace ClassLibrary.Data.Repositories;

public interface IAppointmentsRepository
{
    Task Add(Appointment appointment);
}

public class AppointmentsRepository : Repository, IAppointmentsRepository
{
    public AppointmentsRepository(IConnectionProvider connectionProvider)
        : base(connectionProvider)
    {
    }

    public async Task Add(Appointment appointment)
    {
        using var connection = ConnectionProvider.DbConnection;
        var param = new
        {
            CustomerId = appointment.Customer?.ToString(),
            EmployeeId = appointment.Employee?.ToString(),
            Date = appointment.Date
        };
        appointment = await connection.QueryFirstOrDefaultAsync<Appointment>("spAppointmentsAdd", param, commandType: CommandType.StoredProcedure);
    }
}
