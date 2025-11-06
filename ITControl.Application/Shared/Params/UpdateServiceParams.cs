using ITControl.Domain.Appointments.Params;
using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Shared.Params;

public record UpdateServiceParams
{
    public Guid Id { get; set; }
    public UpdateEntityParams Params { get; set; } = new();
    
    public Entity Props { get; set; } = null!;

    public static implicit operator FindOneServiceParams(
        UpdateServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
            Includes = new IncludesParams()
        };
}