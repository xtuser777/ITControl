using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record FindManyDivisionsParams : FindManyParams
{
    public string? Name { get; set; }
    public Guid? DepartmentId { get; set; }
}
