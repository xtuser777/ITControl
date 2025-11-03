using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Shared.Params;

public record FindManyPaginationServiceParams
{
    public Entity CountProps { get; set; } = null!;
    public FindManyParams CountParams { get; set; } = new();
    public PaginationParams PaginationParams { get; set; } = new();
}