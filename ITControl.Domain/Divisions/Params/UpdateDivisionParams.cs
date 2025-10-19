namespace ITControl.Domain.Divisions.Params;

public record UpdateDivisionParams
{
    public string? Name { get; init; } = null;
    public Guid? DepartmentId { get; init; } = null;

    public void Deconstruct(out string? name, out Guid? departmentId)
    {
        name = Name;
        departmentId = DepartmentId;
    }
}
