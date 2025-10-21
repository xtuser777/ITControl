using ITControl.Domain.Contracts.Params;

namespace ITControl.Application.Contracts.Params;

public record FindManyPaginationContractsServiceParams
{
    public CountContractsRepositoryParams CountParams { get; set; } = new();
    public string? Page { get; set; } = null;
    public string? Size { get; set; } = null;

    public void Deconstruct(out string? page, out string? size)
    {
        page = Page; size = Size;
    }

    public static implicit operator CountContractsRepositoryParams(
        FindManyPaginationContractsServiceParams paginationParams)
        => paginationParams.CountParams;
}
