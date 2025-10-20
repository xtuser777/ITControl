using ITControl.Domain.Calls.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Calls.Params;

public record FindManyCallsServiceParams
{
    public FindManyCallsRepositoryParams FindManyParams { get; set; } = new();
    public OrderByCallsRepositoryParams OrderByParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; }  = new();
}