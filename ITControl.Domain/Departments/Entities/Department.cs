using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Departments.Entities;

public class Department : Entity
{
    public string Alias { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public Department(string alias, string name)
    {
        Id = Guid.NewGuid();
        Alias = alias;
        Name = name;
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

public class UpdateDepartmentParams
{
    public string? Alias { get; set; }
    public string? Name { get; set; }
}