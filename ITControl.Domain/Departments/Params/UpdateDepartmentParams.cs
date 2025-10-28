using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Departments.Params;

public record UpdateDepartmentParams : UpdateEntityParams
{
    public string? Alias { get; init; }
    public string? Name { get; init; }
}
