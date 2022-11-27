// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Data.Base;
using ClassLibrary.Models;

namespace ClassLibrary.Data.Queries;
public class ListEmployeesQuery : Query<ListEmployeesQuery, List<Employee>>
{
	public override ValueTask<List<Employee>> ExecuteAsync()
	{
		return Receiver.Invoke(this);
	}
}
