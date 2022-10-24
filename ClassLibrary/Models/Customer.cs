using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models;

public class Customer : User, IUser
{
    public static Customer Create()
    {
        var customer = new Customer
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DisplayName = String.Empty
        };

        return customer;
    }

    public override DateTime CreatedAt { get; set; }
    public override bool Deleted { get; set; }
    public override int Id { get; set; }
    public override DateTime UpdatedAt { get; set; }
    public List<Appointment>? Appointments { get; set; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome de Exibição do deve conter entre 3 e 100 caracteres.")]
    public override string? DisplayName { get; set; }
}