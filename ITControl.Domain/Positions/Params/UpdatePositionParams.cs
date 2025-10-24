using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Positions.Params;

public record UpdatePositionParams : UpdateEntityParams
{
    public string? Name { get; init; }
}