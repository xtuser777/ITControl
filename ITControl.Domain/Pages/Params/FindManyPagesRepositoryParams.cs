using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record FindManyPagesRepositoryParams : FindManyRepositoryParams
{
    public string? Name { get; set; } = null;
}