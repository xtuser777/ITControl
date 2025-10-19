using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Divisions.Params;

public record OrderByDivisionsRepositoryParams : IOrderByRepositoryParams
{
    public string? Name { get; set; } = null;
    public string? Department { get; set; } = null;
}
