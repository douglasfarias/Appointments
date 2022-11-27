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

public interface IEmployeesHandler
{
	event EventHandler<Employee> EmployeeCreated;
	Task<Employee> HandleAsync(CreateEmployeeCommand command);
	ValueTask<List<Employee>> HandleAsync(ListEmployeesQuery query);
}

public class EmployeesHandler : Handler, ICommandHandler<CreateEmployeeCommand, Employee>, IQueryHandler<ListEmployeesQuery, List<Employee>>, IEmployeesHandler
{
	private readonly IUserFactory _userFactory;
	private readonly IEmployeesRepository _employeesRepository;

	public EmployeesHandler(IUserFactory userFactory, IEmployeesRepository employeesRepository)
	{
		_userFactory = userFactory;
		_employeesRepository = employeesRepository;
	}

	public event EventHandler<Employee>? EmployeeCreated;
	private void OnEmployeeCreated(Employee employee)
	{
		EmployeeCreated?.Invoke(this, employee);
	}

	public async Task<Employee> HandleAsync(CreateEmployeeCommand command)
	{
		var employee = _userFactory.CreateEmployee(command);
		employee = await _employeesRepository.Add(employee);
		OnEmployeeCreated(employee);
		return employee;
	}

	public async ValueTask<List<Employee>> HandleAsync(ListEmployeesQuery query)
	{
		var employees = await _employeesRepository.ToList();
		return employees;
	}
}
