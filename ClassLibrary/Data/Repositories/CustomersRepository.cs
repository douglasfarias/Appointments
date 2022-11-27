// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Data;
using ClassLibrary.Data.Base;
using ClassLibrary.Models;
using Dapper;

namespace ClassLibrary.Data.Repositories;

public interface ICustomersRepository
{
	Task<Customer> Add(Customer user);
	Task<List<Customer>> ToList();
}

public class CustomersRepository : UsersRepository<Customer>, ICustomersRepository
{
	public CustomersRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
	{
	}

	public async Task<List<Customer>> ToList()
	{
		var param = new
		{
			Role = (int)UserRole.Customer
		};
		var connection = ConnectionProvider.GetDbConnection();
		var customers = await connection.QueryAsync<Customer>("spUsersList", param, commandType: CommandType.StoredProcedure);
		return customers.ToList();
	}

}
