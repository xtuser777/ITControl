using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Departments.Params;

public record UpdateDepartmentParams : UpdateEntityParams
{
    public string? Alias { get; init; }
    public string? Name { get; init; }
}
