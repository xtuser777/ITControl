using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record PositionParams : EntityParams
{
    public string Name { get; init; } = string.Empty;
}