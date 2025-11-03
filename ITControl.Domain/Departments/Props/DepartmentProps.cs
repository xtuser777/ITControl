using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Departments.Props;

public class DepartmentProps : Entity
{
    public string? Alias { get; set; }
    public string? Name { get; set; }
}