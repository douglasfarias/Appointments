using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Principal;

namespace ClassLibrary.Models;
public class Customer : ClaimsPrincipal
{
    public Customer()
    {
    }

    public Customer(IEnumerable<ClaimsIdentity> identities) : base(identities)
    {
    }

    public Customer(BinaryReader reader) : base(reader)
    {
    }

    public Customer(IIdentity identity) : base(identity)
    {
    }

    public Customer(IPrincipal principal) : base(principal)
    {
    }

    protected Customer(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override string ToString()
    {
        return Identity?.Name ?? string.Empty;
    }
}
