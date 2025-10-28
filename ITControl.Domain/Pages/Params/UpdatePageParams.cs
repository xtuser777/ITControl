using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record UpdatePageParams : UpdateEntityParams
{
    public string? Name { get; init; }
}