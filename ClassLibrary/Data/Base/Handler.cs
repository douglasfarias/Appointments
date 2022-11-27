// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace ClassLibrary.Data.Base;

public interface IHandler
{
    void SetNext(IHandler handler);
}

public abstract class Handler : IHandler
{
    protected IHandler? NextHandler { get; set; }
    public virtual void SetNext(IHandler handler)
    {
        NextHandler = handler;
    }
}
