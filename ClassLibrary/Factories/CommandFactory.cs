// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Data.Commands;
using ClassLibrary.Data.Queries;
using ClassLibrary.Models;

namespace ClassLibrary.Factories;

public interface ICommandFactory
{
	ListAppointmentsQuery ListAppointmentsQuery(Func<ListAppointmentsQuery, ValueTask<List<Appointment>>> receiver);
	ListCustomersQuery ListCustomersQuery(Func<ListCustomersQuery, ValueTask<List<Customer>>> receiver);
	ListEmployeesQuery ListEmployeesQuery(Func<ListEmployeesQuery, ValueTask<List<Employee>>> receiver);

	CreateAppointmentCommand CreateAppointmentCommand(Func<CreateAppointmentCommand, Task>? receiver);
	CreateCustomerCommand CreateCustomerCommand(Func<CreateCustomerCommand, Task>? receiver);
	CreateEmployeeCommand CreateEmployeeCommand(Func<CreateEmployeeCommand, Task>? receiver);
}

public class CommandFactory : ICommandFactory
{
	public ListCustomersQuery ListCustomersQuery(Func<ListCustomersQuery, ValueTask<List<Customer>>> receiver)
	{
		var query = new ListCustomersQuery
		{
			Receiver = receiver
		};
		return query;
	}

	public ListEmployeesQuery ListEmployeesQuery(Func<ListEmployeesQuery, ValueTask<List<Employee>>> receiver)
	{
		var query = new ListEmployeesQuery
		{
			Receiver = receiver
		};
		return query;
	}

	public ListAppointmentsQuery ListAppointmentsQuery(Func<ListAppointmentsQuery, ValueTask<List<Appointment>>> receiver)
	{
		var query = new ListAppointmentsQuery
		{
			Receiver = receiver,
			StartDate = DateTime.Now,
			EndDate = DateTime.Now
		};
		return query;
	}

	public CreateAppointmentCommand CreateAppointmentCommand(Func<CreateAppointmentCommand, Task>? receiver)
	{
		var command = new CreateAppointmentCommand
		{
			Receiver = receiver,
			Date = DateTime.Now
		};
		return command;
	}

	public CreateCustomerCommand CreateCustomerCommand(Func<CreateCustomerCommand, Task>? receiver)
	{
		var command = new CreateCustomerCommand
		{
			Receiver = receiver,
			Email = string.Empty,
			GivenName = string.Empty,
			Phone = string.Empty,
			SureName = string.Empty
		};
		return command;
	}

	public CreateEmployeeCommand CreateEmployeeCommand(Func<CreateEmployeeCommand, Task>? receiver)
	{
		var command = new CreateEmployeeCommand
		{
			Receiver = receiver,
			Email = string.Empty,
			GivenName = string.Empty,
			Phone = string.Empty,
			SureName = string.Empty
		};
		return command;
	}
}
