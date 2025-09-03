namespace ITControl.Domain.Entities;

public sealed class Position : Entity
{
    public Position(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Description { get; set; } = string.Empty;

    public void Update(string? description)
    {
        Description = description ?? Description;
        UpdatedAt = DateTime.Now;
    }
}