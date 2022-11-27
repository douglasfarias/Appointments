// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

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
		var appointment = new Appointment(date: command.Date,
									customerId: Convert.ToInt32(command.CustomerId),
									employeeId: Convert.ToInt32(command.EmployeeId),
									amountDue: command.AmonutDue,
									amountPaid: command.AmonutPaid);
		return appointment;
	}
}
