using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Departments.Entities;

public class Department : Entity
{
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Department(string alias, string name, Guid userId)
    {
        Id = Guid.NewGuid();
        Alias = alias;
        Name = name;
        UserId = userId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? alias = null, string? name = null, Guid? userId = null)
    {
        Alias = alias ?? Alias;
        Name = name ?? Name;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}