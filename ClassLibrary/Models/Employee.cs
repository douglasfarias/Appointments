using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Principal;

namespace ClassLibrary.Models;
public class Employee : ClaimsPrincipal
{
    public Employee()
    {
    }

    public Employee(IEnumerable<ClaimsIdentity> identities) : base(identities)
    {
    }

    public Employee(BinaryReader reader) : base(reader)
    {
    }

    public Employee(IIdentity identity) : base(identity)
    {
    }

    public Employee(IPrincipal principal) : base(principal)
    {
    }

    protected Employee(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public override string ToString()
    {
        return Identity?.Name ?? string.Empty;
    }
}
