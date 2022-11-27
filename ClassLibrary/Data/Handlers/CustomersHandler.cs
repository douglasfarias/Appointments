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

public interface ICustomersHandler
{
	event EventHandler<Customer> CustomerCreated;
	Task<Customer> HandleAsync(CreateCustomerCommand command);
	ValueTask<List<Customer>> HandleAsync(ListCustomersQuery query);
}

public class CustomersHandler : Handler, ICommandHandler<CreateCustomerCommand, Customer>, IQueryHandler<ListCustomersQuery, List<Customer>>, ICustomersHandler
{
	private readonly IUserFactory _userFactory;
	private readonly ICustomersRepository _customersRepository;

	public CustomersHandler(IUserFactory userFactory, ICustomersRepository customersRepository)
	{
		_userFactory = userFactory;
		_customersRepository = customersRepository;
	}

	public event EventHandler<Customer>? CustomerCreated;
	private void OnCustomerCreated(Customer customer)
	{
		CustomerCreated?.Invoke(this, customer);
	}

	public async Task<Customer> HandleAsync(CreateCustomerCommand command)
	{
		var customer = _userFactory.CreateCustomer(command);
		customer = await _customersRepository.Add(customer);
		OnCustomerCreated(customer);
		return customer;
	}

	public async ValueTask<List<Customer>> HandleAsync(ListCustomersQuery query)
	{
		var customers = await _customersRepository.ToList();
		return customers;
	}
}
