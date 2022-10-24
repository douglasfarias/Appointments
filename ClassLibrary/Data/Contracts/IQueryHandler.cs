namespace ClassLibrary.Data.Contracts;

internal interface IQueryHandler<TQuery, TResult> : IHandler where TQuery : IQuery<TResult> where TResult : class
{
    ValueTask<TResult> Handle(TQuery query);
}
