using ITControl.Domain.Systems.Params;

namespace ITControl.Application.Systems.Params;

public record CreateSystemsServiceParams
{
    public SystemParams Params { get; set; } = new();
}