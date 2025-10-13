namespace ITControl.Domain.Shared.Params;

public record PaginationParams
{
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public void Deconstruct(out int? page, out int? size)
    {
        page = Page;
        size = Size;
    }
}
