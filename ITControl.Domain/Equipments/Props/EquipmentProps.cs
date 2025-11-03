using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Equipments.Props;

public class EquipmentProps : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public EquipmentType? Type { get; set; }
    public string? Ip { get; set; }
    public string? Mac { get; set; }
    public string? Tag { get; set; }
    public bool? Rented { get; set; }
    public Guid? ContractId { get; set; }
    public Contract? Contract { get; set; }
}