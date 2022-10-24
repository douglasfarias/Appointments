namespace ClassLibrary.Data.Contracts;

public interface IQuery<TResult> where TResult : class
{
    ValueTask<TResult> ExecuteAsync();
}

public abstract class Query<TQuery, TResult> : IQuery<TResult> where TQuery : IQuery<TResult> where TResult : class
{
    protected Func<TQuery, ValueTask<TResult>> Receiver;

    protected Query(Func<TQuery, ValueTask<TResult>> receiver)
    {
        Receiver = receiver;
    }

    public abstract ValueTask<TResult> ExecuteAsync();
}
