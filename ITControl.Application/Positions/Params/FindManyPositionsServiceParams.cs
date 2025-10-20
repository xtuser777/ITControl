using ITControl.Domain.Positions.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Positions.Params;

public record FindManyPositionsServiceParams
{
    public FindManyPositionsRepositoryParams FindManyParams { get; set; } = new();
    public OrderByPositionsRepositoryParams OrderByParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
}
