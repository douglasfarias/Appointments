// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Data.Commands;
using ClassLibrary.Models;

namespace ClassLibrary.Factories;

public interface IUserFactory
{
	Customer CreateCustomer(CreateCustomerCommand command);
	Customer CreateCustomer(string email, string givenName, string surname, string phone);
	Employee CreateEmployee(string email, string givenName, string surname, string phone);
	Employee CreateEmployee(CreateEmployeeCommand command);
}

public class UserFactory : IUserFactory
{
	public Customer CreateCustomer(string email, string givenName, string surname, string phone)
	{
		return new Customer(role: UserRole.Customer,
					  givenName: givenName,
					  surename: surname,
					  email: email,
					  phone: phone);
	}

	public Customer CreateCustomer(CreateCustomerCommand command)
	{
		return CreateCustomer(command.Email, command.GivenName, command.SureName, command.Phone);
	}

	public Employee CreateEmployee(string email, string givenName, string surname, string phone)
	{
		return new Employee(role: UserRole.Employee,
					  givenName: givenName,
					  surename: surname,
					  email: email,
					  phone: phone);
	}

	public Employee CreateEmployee(CreateEmployeeCommand command)
	{
		return CreateEmployee(command.Email, command.GivenName, command.SureName, command.Phone);
	}

}
