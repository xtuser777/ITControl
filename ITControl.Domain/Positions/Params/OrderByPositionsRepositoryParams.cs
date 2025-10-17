using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public class OrderByPositionsRepositoryParams : IOrderByRepositoryParams
{
    public string? Name { get; set; } = null;
}