// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ClassLibrary.Models;
public class Day
{
	public Day(int number, string name)
	{
		Number = number;
		Name = name;
	}

	public int Number { get; set; }
	public string Name { get; set; }
}
