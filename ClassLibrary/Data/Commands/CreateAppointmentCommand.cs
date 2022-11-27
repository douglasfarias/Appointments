﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Data.Base;

namespace ClassLibrary.Data.Commands;
public class CreateAppointmentCommand : Command<CreateAppointmentCommand>
{
	public int? CustomerId { get; set; }
	public int? EmployeeId { get; set; }
	public DateTime Date { get; set; }
	public double AmonutDue { get; set; }
	public double AmonutPaid { get; set; }

	public override Task ExecuteAsync()
	{
		return Receiver is null
			? Task.CompletedTask
			: Receiver.Invoke(this);
	}
}
