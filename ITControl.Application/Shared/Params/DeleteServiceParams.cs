namespace ITControl.Application.Shared.Params;

public record DeleteServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(
        DeleteServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}