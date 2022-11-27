// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ClassLibrary.Data.Base;

namespace ClassLibrary.Data.Contracts;
public interface ICommandHandler<TCommand> : IHandler where TCommand : ICommand
{
	Task HandleAsync(TCommand command);
}

public interface ICommandHandler<TCommand, TResult> : IHandler where TCommand : ICommand
{
	Task<TResult> HandleAsync(TCommand command);
}
