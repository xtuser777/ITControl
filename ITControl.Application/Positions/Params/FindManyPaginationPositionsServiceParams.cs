using ITControl.Domain.Positions.Params;

namespace ITControl.Application.Positions.Params;


public record FindManyPaginationPositionsServiceParams
{
    public CountPositionsRepositoryParams CountParams { get; set; } = new();
    public string? Page { get; set; } = null;
    public string? Size { get; set; } = null;
}
