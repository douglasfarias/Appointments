// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Data;
using ClassLibrary.Data.Base;
using ClassLibrary.Models;
using Dapper;

namespace ClassLibrary.Data.Repositories;

public abstract class UsersRepository<TUser> : Repository where TUser : User
{
	public UsersRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
	{
	}

	public virtual async Task<TUser> Add(TUser user)
	{
		var param = new
		{
			user.GivenName,
			user.Surename,
			user.Role,
			user.Email,
			user.Phone
		};
		var connection = ConnectionProvider.GetDbConnection();
		user = await connection.QueryFirstOrDefaultAsync<TUser>("spUsersAdd", param, commandType: CommandType.StoredProcedure);
		return user;
	}
}
