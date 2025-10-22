using ITControl.Domain.Supplements.Params;

namespace ITControl.Application.Supplements.Params;

public record FindManyPaginationSupplementsServiceParams
{
    public CountSupplementsRepositoryParams CountParams { get; set; } = new();
    public string? Page { get; set; }
    public string? Size { get; set; }

    public void Deconstruct(out string? page, out string? size)
    {
        page = Page;
        size = Size;
    }

    public static implicit operator CountSupplementsRepositoryParams(
        FindManyPaginationSupplementsServiceParams param)
        => param.CountParams;
}