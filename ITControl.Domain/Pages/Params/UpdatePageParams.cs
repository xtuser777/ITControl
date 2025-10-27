using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Pages.Params;

public record UpdatePageParams : UpdateEntityParams
{
    public string? Name { get; init; }
}