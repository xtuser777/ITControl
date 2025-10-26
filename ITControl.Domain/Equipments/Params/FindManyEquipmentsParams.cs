using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Equipments.Params;

public record FindManyEquipmentsParams : FindManyParams
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public string? Ip { get; init; }
    public string? Mac { get; init; }
    public string? Tag { get; init; }
    public bool? Rented { get; init; }
    public EquipmentType? Type { get; init; }
}
