// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ClassLibrary.Models.Base;

internal interface IEntity
{
	DateTime CreatedAt { get; set; }
	bool Deleted { get; set; }
	int Id { get; set; }
	DateTime UpdatedAt { get; set; }
}

public abstract class Entity : IEntity
{
	public Entity()
	{

	}

	protected Entity(int id = default,
		DateTime createdAt = default,
		DateTime updatedAt = default,
		bool deleted = default)
	{
		Id = id;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		Deleted = deleted;
	}

	public int Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime UpdatedAt { get; set; }
	public bool Deleted { get; set; }
}
