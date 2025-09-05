using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Entities;
using ITControl.Domain.Users.Entities;

namespace ITControl.Domain.Divisions.Entities;

public class Division : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public Guid UserId { get; set; }

    public Department? Department { get; set; }
    public User? User { get; set; }

    public Division(string name, Guid departmentId, Guid userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        UserId = userId;
        DepartmentId = departmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string? name = null, Guid? departmentId = null, Guid? userId = null)
    {
        Name = name ?? Name;
        DepartmentId = departmentId ?? DepartmentId;
        UserId = userId ?? UserId;
        UpdatedAt = DateTime.Now;
    }
}