namespace ClassLibrary.Data.Repositories;
public abstract class Repository
{
    protected IConnectionProvider ConnectionProvider { get; init; }

    public Repository(IConnectionProvider connectionProvider)
    {
        ConnectionProvider = connectionProvider;
    }
}
