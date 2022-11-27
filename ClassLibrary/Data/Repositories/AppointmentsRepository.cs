// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Data;
using ClassLibrary.Data.Base;
using ClassLibrary.Models;
using Dapper;

namespace ClassLibrary.Data.Repositories;

public interface IAppointmentsRepository
{
	Task<Appointment> Add(Appointment appointment);
	Task<List<Appointment>> ToList(DateTime startDate, DateTime endDate);
}

public class AppointmentsRepository : Repository, IAppointmentsRepository
{
	public AppointmentsRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
	{
	}

	public async Task<Appointment> Add(Appointment appointment)
	{
		var param = new
		{
			appointment.CustomerId,
			appointment.EmployeeId,
			appointment.Date,
			appointment.AmountDue,
			appointment.AmountPaid
		};
		var connection = ConnectionProvider.GetDbConnection();
		appointment = (await connection.QueryAsync<Appointment, Customer, Employee, Appointment>("spAppointmentsAdd", MapToAppoinment, param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
		return appointment;
	}

	public async Task<List<Appointment>> ToList(DateTime startDate, DateTime endDate)
	{
		var param = new
		{
			StartDate = startDate,
			EndDate = endDate
		};
		var connection = ConnectionProvider.GetDbConnection();
		var appointments = await connection.QueryAsync<Appointment, Customer, Employee, Appointment>("spAppointmentsList", MapToAppoinment, param, commandType: CommandType.StoredProcedure);
		return appointments.ToList();
	}

	private static Appointment MapToAppoinment(Appointment appointment, Customer customer, Employee employee)
	{
		appointment.Customer = customer;
		appointment.Employee = employee;
		return appointment;
	}
}
