using ClassLibrary.Models;

using System.Security.Claims;

namespace ClassLibrary.Factories;

public class UserFactory
{
    private static ClaimsPrincipal CreatePrincipal(string name, string givenName, string surname, string role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, name),
            new Claim(ClaimTypes.GivenName, givenName),
            new Claim(ClaimTypes.Surname, surname),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.AuthenticationMethod, "password"),
        };
        var identity = new ClaimsIdentity(claims);
        return new ClaimsPrincipal(identity);
    }

    public static Customer CreateCustomer(string name, string givenName, string surname)
    {
        return new Customer(CreatePrincipal(name, givenName, surname, "customer"));
    }

    public static Employee CreateEmployee(string name, string givenName, string surname)
    {
        return new Employee(CreatePrincipal(name, givenName, surname, "employee"));
    }
}
