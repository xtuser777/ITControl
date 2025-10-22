namespace ITControl.Application.Supplements.Params;

public record DeleteSupplementsServiceParams
{
    public Guid Id { get; init; }

    public static implicit operator FindOneSupplementsServiceParams(
        DeleteSupplementsServiceParams param)
        => new()
        {
            Id = param.Id,
        };
}