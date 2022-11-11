using System.Security.Claims;
using System.Security.Principal;

namespace ClassLibrary.Models;

public enum UserRoles
{
    Employee,
    Customer
}

public interface IUser : IPrincipal
{
    DateTime CreatedAt { get; set; }
    bool Deleted { get; set; }
    string DisplayName { get; }
    int Id { get; set; }
    DateTime UpdatedAt { get; set; }
}

public abstract class User : ClaimsPrincipal, IEntity, IUser
{
    protected User(IPrincipal principal) : base(principal)
    {
    }

    public abstract DateTime CreatedAt { get; set; }
    public abstract bool Deleted { get; set; }
    public abstract int Id { get; set; }
    public abstract DateTime UpdatedAt { get; set; }
    public virtual string DisplayName
    {
        get
        {
            return $"{GetGivenName()} {GetSureName()}";
        }
    }

    private string? GetSureName()
    {
        return Claims?.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Surname))?.Value;
    }

    private string? GetGivenName()
    {
        return Claims?.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.GivenName))?.Value;
    }

    public override bool Equals(object? obj) => obj != null && ((User)obj).Id.Equals(Id);

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString() => DisplayName;
}