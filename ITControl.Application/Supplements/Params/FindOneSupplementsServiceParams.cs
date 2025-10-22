using ITControl.Domain.Supplements.Params;

namespace ITControl.Application.Supplements.Params;

public record FindOneSupplementsServiceParams
{
    public Guid Id { get; init; }

    public static implicit operator FindOneSupplementsRepositoryParams(
        FindOneSupplementsServiceParams serviceParams)
        => new()
        {
            Id = serviceParams.Id,
        };
}