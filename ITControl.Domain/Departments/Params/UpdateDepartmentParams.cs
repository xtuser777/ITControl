namespace ITControl.Domain.Departments.Params;

public record UpdateDepartmentParams
{
    public string? Alias { get; init; } = null;
    public string? Name { get; init; } = null;
}
