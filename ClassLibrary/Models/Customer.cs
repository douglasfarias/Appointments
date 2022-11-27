// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ClassLibrary.Models;
public class Customer : User
{
	public Customer()
	{

	}

	public Customer(UserRole role,
				 string givenName,
				 string surename,
				 string email,
				 string phone,
				 int id = 0,
				 DateTime createdAt = default,
				 DateTime updatedAt = default,
				 bool deleted = false) : base(role, givenName, surename, email, phone, id, createdAt, updatedAt, deleted)
	{
	}
}
