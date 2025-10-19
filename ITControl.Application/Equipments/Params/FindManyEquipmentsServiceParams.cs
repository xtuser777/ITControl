using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Params;

namespace ITControl.Application.Equipments.Params;

public record FindManyEquipmentsServiceParams
{
    public FindManyEquipmentsRepositoryParams FindManyParams { get; set; } = null!;
    public OrderByEquipmentsRepositoryParams OrderByParams { get; set; } = null!;
    public PaginationParams PaginationParams { get; set; } = null!;
}