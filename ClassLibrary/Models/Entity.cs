namespace ClassLibrary.Models;

internal interface IEntity
{
    DateTime CreatedAt { get; set; }
    bool Deleted { get; set; }
    int Id { get; set; }
    DateTime UpdatedAt { get; set; }
}

internal abstract class Entity : IEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Deleted { get; set; }
}
