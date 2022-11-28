// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using ClassLibrary.Data.Base;

namespace ClassLibrary.Data.Commands;
public class CreateAppointmentCommand : Command<CreateAppointmentCommand>
{
	[Required]
	public int? CustomerId { get; set; }
	[Required]
	public int? EmployeeId { get; set; }
	[Required]
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
