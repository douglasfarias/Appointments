namespace ClassLibrary.Models;

public class Service : IEntity
{
    public DateTime CreatedAt { get; set; }
    public bool Deleted { get; set; }
    public int Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int OwnerId { get; set; }
    public User? Owner { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }

    public override bool Equals(object? obj) => obj != null && ((Service)obj).Id.Equals(Id);

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString() => Name;
}