using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record FindManyPositionsRepositoryParams : FindManyRepositoryParams
{
    public string? Name { get; set; } = null;
}