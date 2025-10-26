using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Divisions.Params;

public record DivisionParams : EntityParams
{
    public string Name { get; init; } = string.Empty;
    public Guid DepartmentId { get; init; }
}
