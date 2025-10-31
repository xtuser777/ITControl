using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Shared.Params;

public record CreateServiceParams
{
    public EntityParams Params { get; set; } = new();
    public Entity Props { get; set; } = null!;
}