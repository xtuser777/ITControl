using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Positions.Params;

public record FindManyPositionsParams : FindManyParams
{
    public string? Name { get; set; }
}