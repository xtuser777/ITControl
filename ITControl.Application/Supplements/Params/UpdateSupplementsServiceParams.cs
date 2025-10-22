using ITControl.Domain.Supplements.Params;

namespace ITControl.Application.Supplements.Params;

public record UpdateSupplementsServiceParams
{
    public Guid Id { get; init; }
    public UpdateSupplementParams Params { get; set; } = new();

    public static implicit operator FindOneSupplementsServiceParams(
        UpdateSupplementsServiceParams param)
        => new()
        {
            Id = param.Id,
        };
}