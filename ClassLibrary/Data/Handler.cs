namespace ClassLibrary.Data;

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