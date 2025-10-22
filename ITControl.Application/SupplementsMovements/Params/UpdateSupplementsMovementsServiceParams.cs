using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Application.SupplementsMovements.Params;

public record UpdateSupplementsMovementsServiceParams
{
    public Guid Id { get; set; }
    public UpdateSupplementMovementParams Params { get; set; } = new();

    public static implicit operator FindOneSupplementsMovementsServiceParams(
        UpdateSupplementsMovementsServiceParams param)
        => new()
        {
            Id = param.Id,
        };
}