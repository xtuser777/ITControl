using ITControl.Domain.Divisions.Params;

namespace ITControl.Application.Divisions.Params;

public record FindManyPaginationDivisionsServiceParams
{
    public CountDivisionsRepositoryParams CountParams { get; set; } = null!;
    public string? Page { get; set; } =  null;
    public string? Size { get; set; } =  null;
}