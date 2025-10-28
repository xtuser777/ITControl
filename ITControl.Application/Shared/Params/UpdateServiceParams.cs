using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Shared.Params;

public record UpdateServiceParams
{
    public Guid Id { get; set; }
    public UpdateEntityParams Params { get; set; } = new();

    public static implicit operator FindOneServiceParams(
        UpdateServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}