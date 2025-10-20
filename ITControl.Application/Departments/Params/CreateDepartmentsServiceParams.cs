using ITControl.Domain.Departments.Params;

namespace ITControl.Application.Departments.Params;

public record CreateDepartmentsServiceParams
{
    public DepartmentParams Params { get; set; } = null!;
}
