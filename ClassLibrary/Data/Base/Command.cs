// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ClassLibrary.Data.Base;

public interface ICommand
{
	Task ExecuteAsync();
}

public abstract class Command<TCommand> : ICommand where TCommand : ICommand
{
	public Func<TCommand, Task>? Receiver { get; set; }
	public abstract Task ExecuteAsync();
}
