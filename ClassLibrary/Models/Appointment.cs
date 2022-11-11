namespace ClassLibrary.Models;
public class Appointment : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Deleted { get; set; }
    public DateTime Date { get; set; }
    public IList<Service>? Services { get; set; }
    public bool Done { get; set; }
    public Customer? Customer { get; set; }
    public Employee? Employee { get; set; }
    public double AmountDue { get; set; }
    public double AmountPaid { get; set; }

    public override bool Equals(object? obj) => obj != null && ((Appointment)obj).Id.Equals(Id);

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
