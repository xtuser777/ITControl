using ITControl.Domain.SupplementsMovements.Params;

namespace ITControl.Application.SupplementsMovements.Params;

public record FindManyPaginationSupplementsMovementsServiceParams
{
    public CountSupplementsMovementsRepositoryParams 
        CountSupplementsMovementsRepositoryParams { get; set; } = new();
    public string? Page { get; set; }
    public string? Size { get; set; }

    public void Deconstruct(out string? page, out string? size)
    {
        page = Page;
        size = Size;
    }

    public static implicit operator CountSupplementsMovementsRepositoryParams(
        FindManyPaginationSupplementsMovementsServiceParams param)
        => param.CountSupplementsMovementsRepositoryParams;
}