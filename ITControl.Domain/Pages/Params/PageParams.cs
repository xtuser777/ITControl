using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record PageParams : EntityParams
{
    public string Name { get; init; } = string.Empty;
}