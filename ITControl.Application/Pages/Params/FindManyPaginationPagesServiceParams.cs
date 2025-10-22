using ITControl.Domain.Pages.Params;

namespace ITControl.Application.Pages.Params;

public record FindManyPaginationPagesServiceParams
{
    public CountPagesRepositoryParams CountParams { get; init; } = new();
    public string? Page { get; init; } = null;
    public string? Size { get; init; } = null;

    public void Deconstruct(out string? page, out string? size)
    {
        page = Page;
        size = Size;
    }
    
    public static implicit operator CountPagesRepositoryParams(
        FindManyPaginationPagesServiceParams @params)
        => @params.CountParams;
}
