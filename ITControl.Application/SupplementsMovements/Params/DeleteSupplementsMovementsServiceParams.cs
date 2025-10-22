using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Application.SupplementsMovements.Params;

public record DeleteSupplementsMovementsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneSupplementsMovementsServiceParams(
        DeleteSupplementsMovementsServiceParams param)
        => new()
        {
            Id = param.Id,
        };
}