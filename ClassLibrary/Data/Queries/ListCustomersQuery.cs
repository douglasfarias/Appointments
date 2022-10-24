using ClassLibrary.Data.Contracts;
using ClassLibrary.Models;

namespace ClassLibrary.Data.Queries;
public class ListCustomersQuery : Query<ListCustomersQuery, IEnumerable<Customer>>, IQuery<IEnumerable<Customer>>
{
    public ListCustomersQuery(Func<ListCustomersQuery, ValueTask<IEnumerable<Customer>>> receiver) : base(receiver)
    {
    }

    public override ValueTask<IEnumerable<Customer>> ExecuteAsync()
    {
        return Receiver.Invoke(this);
    }
}
