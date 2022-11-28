// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using ClassLibrary.Data.Base;

namespace ClassLibrary.Data.Commands;
public class CreateEmployeeCommand : Command<CreateEmployeeCommand>
{
	[Required]
	public string? GivenName { get; set; }
	[Required]
	public string? SureName { get; set; }
	[Required]
	public string? Phone { get; set; }
	public string? Email { get; set; }

	public override Task ExecuteAsync()
	{
		return Receiver is null
			? Task.CompletedTask
			: Receiver.Invoke(this);
	}
}
