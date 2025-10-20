using ITControl.Domain.Pages.Params;

namespace ITControl.Application.Pages.Params;

public record FindManyPaginationPagesServiceParams
{
    public CountPagesRepositoryParams CountParams { get; set; } = new();
    public string? Page { get; set; } = null;
    public string? Size { get; set; } = null;
}
