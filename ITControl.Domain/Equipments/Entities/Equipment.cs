using ITControl.Domain.Contracts.Entities;
using ITControl.Domain.Equipments.Enums;
using ITControl.Domain.Equipments.Params;
using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Equipments.Entities;

public sealed class Equipment : Entity
{
    public Equipment() { }

    public Equipment(EquipmentParams @params)
    {
        Id = Guid.NewGuid();
        Name = @params.Name;
        Description = @params.Description;
        Type = @params.Type;
        Ip = @params.Ip;
        Mac = @params.Mac;
        Tag = @params.Tag;
        Rented = @params.Rented;
        ContractId = @params.ContractId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public EquipmentType Type { get; set; }
    public string Ip { get; set; } = string.Empty;
    public string Mac { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    public bool Rented { get; set; }
    public Guid? ContractId { get; set; }
    public Contract? Contract { get; set; }

    public void Update(UpdateEquipmentParams @params)
    {
        Name = @params.Name ?? Name;
        Description = @params.Description ?? Description;
        Type = @params.Type ?? Type;
        Ip = @params.Ip ?? Ip;
        Mac = @params.Mac ?? Mac;
        Tag = @params.Tag ?? Tag;
        Rented = @params.Rented ?? Rented;
        ContractId = @params.ContractId ?? ContractId;
        UpdatedAt = DateTime.UtcNow;
    }
}