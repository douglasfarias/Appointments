// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Models.Base;

namespace ClassLibrary.Models;

public class Service : Entity
{
	public Service()
	{

	}

	public Service(string? name,
				double price,
				int id = 0,
				DateTime createdAt = default,
				DateTime updatedAt = default,
				bool deleted = false) : base(id, createdAt, updatedAt, deleted)
	{
		Name = name;
		Price = price;
	}

	public string? Name { get; set; }
	public double Price { get; set; }

	public override bool Equals(object? obj) => obj != null && ((Service)obj).Id.Equals(Id);

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string? ToString() => Name;
}
