using System.Security.Claims;

namespace ClassLibrary.Extensions;
public static class ClaimsPrincipalExtensions
{
    public static string GetFullName(this ClaimsPrincipal principal)
        => string.Format("{0} {1}",
            principal?.Claims?.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.GivenName))?.Value,
            principal?.Claims?.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Surname))?.Value);
}
