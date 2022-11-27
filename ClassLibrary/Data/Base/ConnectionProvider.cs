// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Data;

namespace ClassLibrary.Data.Base;

public interface IConnectionProvider
{
	IDbConnection GetDbConnection();
}

public abstract class ConnectionProvider : IConnectionProvider
{
	protected readonly IDbConnection _dbConnection;

	protected ConnectionProvider(IDbConnection dbConnection)
	{
		_dbConnection = dbConnection;
	}

	public virtual IDbConnection GetDbConnection()
	{
		if (_dbConnection.State != ConnectionState.Open)
			_dbConnection.Open();

		return _dbConnection;
	}

}
