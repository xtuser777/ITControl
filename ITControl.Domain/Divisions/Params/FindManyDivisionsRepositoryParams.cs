using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record FindManyDivisionsRepositoryParams : FindManyRepositoryParams
{
    public string? Name { get; set; } = null;
    public Guid? DepartmentId { get; set; } = null;
}
