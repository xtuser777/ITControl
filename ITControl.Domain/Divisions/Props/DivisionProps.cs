using ITControl.Domain.Departments.Entities;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Divisions.Props;

public class DivisionProps : Entity
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }

    public Department? Department { get; set; }
}