using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Positions.Params;

public record UpdatePositionParams : UpdateEntityParams
{
    public string? Name { get; init; }
}