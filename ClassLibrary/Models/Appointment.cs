// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Models.Base;

namespace ClassLibrary.Models;
public class Appointment : Entity
{
	public Appointment()
	{

	}

	public Appointment(DateTime date,
					IList<Service>? services = default,
					bool done = default,
					Customer? customer = default,
					Employee? employee = default,
					double amountDue = default,
					double amountPaid = default,
					int customerId = default,
					int employeeId = default,
					int id = 0,
					DateTime createdAt = default,
					DateTime updatedAt = default,
					bool deleted = false) : base(id, createdAt, updatedAt, deleted)
	{
		Date = date;
		Services = services;
		Done = done;
		Customer = customer;
		Employee = employee;
		AmountDue = amountDue;
		AmountPaid = amountPaid;
		CustomerId = customerId;
		EmployeeId = employeeId;
	}

	public DateTime Date { get; set; }
	public IList<Service>? Services { get; set; }
	public bool Done { get; set; }
	public Customer? Customer { get; set; }
	public int CustomerId { get; set; }
	public Employee? Employee { get; set; }
	public int EmployeeId { get; set; }
	public double AmountDue { get; set; }
	public double AmountPaid { get; set; }

	public override bool Equals(object? obj) => obj != null && ((Appointment)obj).Id.Equals(Id);

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

}
