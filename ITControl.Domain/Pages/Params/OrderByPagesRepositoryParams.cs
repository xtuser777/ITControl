using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record OrderByPagesRepositoryParams : OrderByRepositoryParams
{
    public string? Name { get; set; } = null;
}