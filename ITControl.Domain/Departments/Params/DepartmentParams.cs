namespace ITControl.Domain.Departments.Params;

public record DepartmentParams
{
    public string Alias { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
}
