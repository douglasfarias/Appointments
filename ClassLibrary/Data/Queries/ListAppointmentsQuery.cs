// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Data.Base;
using ClassLibrary.Models;

namespace ClassLibrary.Data.Queries;
public class ListAppointmentsQuery : Query<ListAppointmentsQuery, List<Appointment>>
{
	public ListAppointmentsQuery()
	{

	}

	public override ValueTask<List<Appointment>> ExecuteAsync()
	{
		return Receiver.Invoke(this);
	}

	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
}
