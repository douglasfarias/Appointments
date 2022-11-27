// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Data;
using ClassLibrary.Data.Base;

namespace ClassLibrary.Data.Providers;
public class SqlServerConnectionProvider : ConnectionProvider, IConnectionProvider
{
	public SqlServerConnectionProvider(IDbConnection dbConnection) : base(dbConnection)
	{
	}
}
