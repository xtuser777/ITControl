using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Positions.Params;

public record OrderByPositionsParams : OrderByParams
{
    public string? Name { get; set; }
}