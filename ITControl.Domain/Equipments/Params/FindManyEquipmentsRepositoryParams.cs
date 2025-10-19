using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Equipments.Params;

public record FindManyEquipmentsRepositoryParams : FindManyRepositoryParams
{
    public string? Name { get; init; } = null;
    public string? Description { get; init; } = null;
    public string? Ip { get; init; } = null;
    public string? Mac { get; init; } = null;
    public string? Tag { get; init; } = null;
    public bool? Rented { get; init; } = null;
    public EquipmentType? Type { get; init; } = null;
}
