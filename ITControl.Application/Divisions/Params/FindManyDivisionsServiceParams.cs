using ITControl.Domain.Divisions.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Divisions.Params;

public record FindManyDivisionsServiceParams
{
    public FindManyDivisionsRepositoryParams FindManyParams { get; set; } = null!;
    public OrderByDivisionsRepositoryParams OrderByParams { get; set; } =  null!;
    public PaginationParams PaginationParams { get; set; } = null!;
}