using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Shared.Params;

public record FindManyRepositoryParams
{
    public Entity FindManyProps { get; set; } = null!;
    public FindManyParams FindMany { get; set; } = new();
    public OrderByParams OrderBy { get; set; } = new();
    public PaginationParams Pagination { get; set; } = new();
}