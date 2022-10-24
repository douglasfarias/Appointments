namespace ClassLibrary.Models;
public class Appointment : IEntity
{
    public DateTime CreatedAt { get; set; }
    public bool Deleted { get; set; }
    public int Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int OwnerId { get; set; }
    public User? Owner { get; set; }
    public DateTime Date { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public List<Service>? Services { get; set; }
    public bool Done { get; set; }

    public override bool Equals(object? obj) => obj != null && ((Appointment)obj).Id.Equals(Id);

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return $"{Date:dd/MM/yyyy} - {Customer}";
    }
}
