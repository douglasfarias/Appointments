// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ClassLibrary.Models;
public class Unsubscriber<T> : IDisposable
{
	private readonly List<IObserver<T>> _observers;
	private readonly IObserver<T> _observer;
	public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
	{
		_observers = observers;
		_observer = observer;
	}

	public void Dispose()
	{
		if (!(_observer == null))
			_observers.Remove(_observer);

		GC.SuppressFinalize(this);
	}
}
