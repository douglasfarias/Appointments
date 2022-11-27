// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Data;
using ClassLibrary.Data.Base;
using ClassLibrary.Models;
using Dapper;

namespace ClassLibrary.Data.Repositories;

public interface IEmployeesRepository
{
	Task<Employee> Add(Employee user);
	Task<List<Employee>> ToList();
}

public class EmployeesRepository : UsersRepository<Employee>, IEmployeesRepository
{
	public EmployeesRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
	{
	}

	public async Task<List<Employee>> ToList()
	{
		var param = new
		{
			Role = (int)UserRole.Employee
		};
		var connection = ConnectionProvider.GetDbConnection();
		var employees = await connection.QueryAsync<Employee>("spUsersList", param, commandType: CommandType.StoredProcedure);
		return employees.ToList();
	}
}
