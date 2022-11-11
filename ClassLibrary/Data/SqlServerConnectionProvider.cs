using System.Data;

namespace ClassLibrary.Data;
public class SqlServerConnectionProvider : ConnectionProvider, IConnectionProvider
{
    private SqlServerConnectionProvider(IDbConnection dbConnection) : base(dbConnection)
    {
    }

    public static SqlServerConnectionProvider CreateInstance(IDbConnection dbConnection)
    {
        return new SqlServerConnectionProvider(dbConnection);
    }
}
