namespace ITControl.Domain.Divisions.Params;

public record DivisionParams
{
    public string Name { get; init; } = string.Empty;
    public Guid DepartmentId { get; init; }
}
