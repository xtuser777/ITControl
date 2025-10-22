using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Shared.Params2;

public record FindManyRepositoryParams
{
    public FindManyParams FindMany { get; set; } = new();
    public OrderByParams OrderBy { get; set; } = new();
    public PaginationParams Pagination { get; set; } = new();
}