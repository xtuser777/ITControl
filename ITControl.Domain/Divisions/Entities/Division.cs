using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Divisions.Entities;

public class Division : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public Division(string name, Guid departmentId)
    {
        Id = Guid.NewGuid();
        Name = name;
        DepartmentId = departmentId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateDivisionParams @params)
    {
        var (name, departmentId) = @params;
        Name = name ?? Name;
        DepartmentId = departmentId ?? DepartmentId;
        UpdatedAt = DateTime.Now;
    }
}