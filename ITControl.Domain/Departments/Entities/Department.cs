using ITControl.Domain.Departments.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Departments.Entities;

public class Department : Entity
{
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public Department() { }

    public Department(DepartmentParams @params)
    {
        Id = Guid.NewGuid();
        Alias = @params.Alias;
        Name = @params.Name;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(UpdateDepartmentParams @params)
    {
        Alias = @params.Alias ?? Alias;
        Name = @params.Name ?? Name;
        UpdatedAt = DateTime.Now;
    }
}
