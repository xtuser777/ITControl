using ITControl.Domain.Calls.Params;

namespace ITControl.Application.Calls.Params;

public record FindManyPaginationCallsServiceParams
{
    public CountCallsRepositoryParams CountParams { get; set; } = new();
    public string? Page { get; set; } = null;
    public string? Size { get; set; } = null;
}