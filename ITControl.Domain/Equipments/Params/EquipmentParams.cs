using ITControl.Domain.Equipments.Enums;

namespace ITControl.Domain.Equipments.Params;

public record EquipmentParams
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public EquipmentType Type { get; init; }
    public string Ip { get; init; } = string.Empty;
    public string Mac { get; init; } = string.Empty;
    public string Tag { get; init; } = string.Empty;
    public bool Rented { get; init; }
    public Guid? ContractId { get; init; }
}
