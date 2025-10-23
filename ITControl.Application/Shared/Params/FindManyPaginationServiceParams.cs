using ITControl.Domain.Shared.Params;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Application.Shared.Params;

public record FindManyPaginationServiceParams
{
    public FindManyParams CountParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
}