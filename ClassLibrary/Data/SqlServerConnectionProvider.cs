using System.Data;

namespace ClassLibrary.Data;
public class SqlServerConnectionProvider : ConnectionProvider, IConnectionProvider
{
    public SqlServerConnectionProvider(IDbConnection dbConnection) : base(dbConnection)
    {
    }
}
