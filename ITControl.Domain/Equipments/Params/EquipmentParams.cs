using ITControl.Domain.Equipments.Enums;

namespace ITControl.Domain.Equipments.Params;

public record EquipmentParams
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public EquipmentType Type { get; set; }
    public string Ip { get; set; } = string.Empty;
    public string Mac { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    public bool Rented { get; set; }
    public Guid? ContractId { get; set; }
}
