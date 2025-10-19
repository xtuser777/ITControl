using ITControl.Domain.Equipments.Params;

namespace ITControl.Application.Equipments.Params;

public record FindManyPaginationEquipmentsServiceParams
{
    public CountEquipmentsRepositoryParams CountParams { get; init; } = null!;
    public string? Page { get; init; } = null;
    public string? Size { get; init; } = null;
}