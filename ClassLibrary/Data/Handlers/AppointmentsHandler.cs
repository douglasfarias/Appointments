// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Data.Base;
using ClassLibrary.Data.Commands;
using ClassLibrary.Data.Contracts;
using ClassLibrary.Data.Queries;
using ClassLibrary.Data.Repositories;
using ClassLibrary.Factories;
using ClassLibrary.Models;

namespace ClassLibrary.Data.Handlers;

public interface IAppointmentsHandler
{

	event EventHandler<Appointment> AppointmentCreated;
	Task<Appointment> HandleAsync(CreateAppointmentCommand command);
	ValueTask<List<Appointment>> HandleAsync(ListAppointmentsQuery query);
}

public class AppointmentsHandler : Handler, ICommandHandler<CreateAppointmentCommand, Appointment>, IQueryHandler<ListAppointmentsQuery, List<Appointment>>, IAppointmentsHandler
{
	private readonly IAppointmentsFactory _factory;
	private readonly IAppointmentsRepository _repository;

	public AppointmentsHandler(IAppointmentsFactory factory, IAppointmentsRepository repository)
	{
		_factory = factory;
		_repository = repository;
	}

	public event EventHandler<Appointment>? AppointmentCreated;

	private void OnAppointmentCreated(Appointment appointment)
	{
		AppointmentCreated?.Invoke(this, appointment);
	}

	public async Task<Appointment> HandleAsync(CreateAppointmentCommand command)
	{
		var appointment = _factory.Create(command);
		appointment = await _repository.Add(appointment);
		OnAppointmentCreated(appointment);
		return appointment;
	}

	public async ValueTask<List<Appointment>> HandleAsync(ListAppointmentsQuery query)
	{
		var appointments = await _repository.ToList(query.StartDate, query.EndDate);
		return appointments;
	}
}
