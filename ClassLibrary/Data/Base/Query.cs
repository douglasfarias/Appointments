// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ClassLibrary.Data.Base;

public interface IQuery<TResult> where TResult : class
{
	ValueTask<TResult> ExecuteAsync();
}

public abstract class Query<TQuery, TResult> : IQuery<TResult> where TQuery : IQuery<TResult> where TResult : class
{
	public Func<TQuery, ValueTask<TResult>> Receiver;

	public abstract ValueTask<TResult> ExecuteAsync();
}
