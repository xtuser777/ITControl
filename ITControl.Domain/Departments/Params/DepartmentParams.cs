using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Departments.Params;

public record DepartmentParams : EntityParams
{
    public string Alias { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
}
