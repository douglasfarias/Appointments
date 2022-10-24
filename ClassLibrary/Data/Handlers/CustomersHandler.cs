using ClassLibrary.Data.Commands;
using ClassLibrary.Data.Contracts;
using ClassLibrary.Data.Queries;
using ClassLibrary.Models;

using Dapper;

namespace ClassLibrary.Data.Handlers;
public class CustomersHandler : Handler, IQueryHandler<ListCustomersQuery, IEnumerable<Customer>>, ICommandHandler<CreateCustomerCommand>
{
    public CustomersHandler(IConnectionProvider connectionProvider) : base(connectionProvider)
    {
    }

    public async ValueTask<IEnumerable<Customer>> Handle(ListCustomersQuery query)
    {
        const string sql = "select * from tbCustomers";
        using var connection = ConnectionProvider.DbConnection;
        var data = await connection.QueryAsync<Customer>(sql, query);
        return data;
    }

    public async Task Handle(CreateCustomerCommand command)
    {
        const string sql = "insert into tbCustomers (Name, DisplayName) values (@Name, @DisplayName)";
        using var connection = ConnectionProvider.DbConnection;
        _ = await connection.ExecuteAsync(sql, command);
    }
}
