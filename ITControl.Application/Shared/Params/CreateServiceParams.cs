using ITControl.Domain.Shared.Params2;

namespace ITControl.Application.Shared.Params;

public record CreateServiceParams
{
    public EntityParams Params { get; set; } = new();
}