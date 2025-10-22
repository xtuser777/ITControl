using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Application.SupplementsMovements.Params;

public record CreateSupplementsMovementsServiceParams
{
    public SupplementMovementParams Params { get; set; } = new();
}