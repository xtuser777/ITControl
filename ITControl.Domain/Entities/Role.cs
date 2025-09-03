namespace ITControl.Domain.Entities;

public sealed class Role : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool Active { get; set; }

    public ICollection<RolePage>? RolesPages { get; set; }

    public Role(string name, bool active)
    {
        Id = Guid.NewGuid();
        Name = name;
        Active = active;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? name = null, bool? active = null)
    {
        Name = name ?? Name;
        Active = active ?? Active;
        UpdatedAt = DateTime.Now;
    }
}