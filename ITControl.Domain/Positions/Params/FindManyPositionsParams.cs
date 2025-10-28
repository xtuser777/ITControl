using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record FindManyPositionsParams : FindManyParams
{
    public string? Name { get; set; }
}