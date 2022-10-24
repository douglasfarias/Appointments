using System.Security.Claims;
using System.Security.Principal;

namespace ClassLibrary.Models;

public interface IUser : IPrincipal
{
    DateTime CreatedAt { get; set; }
    bool Deleted { get; set; }
    string? DisplayName { get; set; }
    int Id { get; set; }
    DateTime UpdatedAt { get; set; }
}

public abstract class User : ClaimsPrincipal, IEntity, IUser
{
    public abstract DateTime CreatedAt { get; set; }
    public abstract bool Deleted { get; set; }
    public abstract int Id { get; set; }
    public abstract DateTime UpdatedAt { get; set; }
    public abstract string? DisplayName { get; set; }

    public override bool Equals(object? obj) => obj != null && ((User)obj).Id.Equals(Id);

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString() => DisplayName;
}