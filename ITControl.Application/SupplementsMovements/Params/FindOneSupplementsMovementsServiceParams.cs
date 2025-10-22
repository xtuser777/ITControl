using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Application.SupplementsMovements.Params;

public record FindOneSupplementsMovementsServiceParams
{
    public Guid Id { get; set; }
    public IncludesSupplementsMovementsParams? Includes { get; set; } = new();

    public static implicit operator FindOneSupplementsMovementsRepositoryParams(
        FindOneSupplementsMovementsServiceParams param)
        => new()
        {
            Id = param.Id,
            Includes = param.Includes,
        };
}