using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record OrderByPositionsParams : OrderByParams
{
    public string? Name { get; set; }
}