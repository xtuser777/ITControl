using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Positions.Params;

public record PositionParams : EntityParams
{
    public string Name { get; init; } = string.Empty;
}