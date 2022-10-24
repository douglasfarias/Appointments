using System.Data;

namespace ClassLibrary.Data;

public interface IConnectionProvider
{
	IDbConnection DbConnection { get; }
}

public abstract class ConnectionProvider : IConnectionProvider
{
	private readonly IDbConnection _dbConnection;

	protected ConnectionProvider(IDbConnection dbConnection)
	{
		_dbConnection = dbConnection;
	}

	public virtual IDbConnection DbConnection
	{
		get
		{
			_dbConnection.Open();
			return _dbConnection;
		}
	}

}
