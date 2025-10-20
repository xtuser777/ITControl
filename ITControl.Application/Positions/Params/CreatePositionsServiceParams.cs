using ITControl.Domain.Positions.Params;

namespace ITControl.Application.Positions.Params;

public record CreatePositionsServiceParams
{
    public PositionParams Params { get; set; } = new();
}
