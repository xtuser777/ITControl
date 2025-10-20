using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record OrderByPositionsRepositoryParams : OrderByRepositoryParams
{
    public string? Name { get; set; } = null;
}