using ITControl.Domain.Systems.Params;

namespace ITControl.Application.Systems.Params;

public record UpdateSystemsServiceParams
{
    public Guid Id { get; set; }
    public UpdateSystemParams Params { get; set; } = new();

    public static implicit operator FindOneSystemsServiceParams(
        UpdateSystemsServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}