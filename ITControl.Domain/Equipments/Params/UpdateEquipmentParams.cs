using ITControl.Domain.Equipments.Enums;

namespace ITControl.Domain.Equipments.Params;

public record UpdateEquipmentParams
{
    public string? Name { get; set; } = null;
    public string? Description { get; set; } = null;
    public EquipmentType? Type { get; set; } = null;
    public string? Ip { get; set; } = null;
    public string? Mac { get; set; } = null;
    public string? Tag { get; set; } = null;
    public bool? Rented { get; set; } = null;
    public Guid? ContractId { get; set; } = null;
}
