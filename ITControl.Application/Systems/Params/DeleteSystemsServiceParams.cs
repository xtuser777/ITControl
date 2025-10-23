namespace ITControl.Application.Systems.Params;

public record DeleteSystemsServiceParams
{
    public Guid Id { get; set; }

    public static implicit operator FindOneSystemsServiceParams(
        DeleteSystemsServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}