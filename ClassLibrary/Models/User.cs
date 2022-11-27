// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Models.Base;

namespace ClassLibrary.Models;

public abstract class User : Entity
{
	public User()
	{

	}

	public User(UserRole role,
			 string givenName,
			 string surename,
			 string email,
			 string phone,
			 int id = 0,
			 DateTime createdAt = default,
			 DateTime updatedAt = default,
			 bool deleted = false) : base(id, createdAt, updatedAt, deleted)
	{
		Role = role;
		GivenName = givenName;
		Surename = surename;
		Email = email;
		Phone = phone;
	}

	public UserRole Role { get; set; }
	public string GivenName { get; set; }
	public string Surename { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }

	public override string ToString()
	{
		return GetFullName();
	}

	public string GetFullName()
	{
		return $"{GivenName} {Surename}";
	}
}
