using ITControl.Domain.Enums;
using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Equipment : Entity
{
    public Equipment(
        string name, 
        string description, 
        EquipmentType type, 
        string ip, 
        string mac, 
        string tag, 
        bool rented, 
        Guid? contractId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Type = type;
        Ip = ip;
        Mac = mac;
        Tag = tag;
        Rented = rented;
        ContractId = contractId;
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

    public void Update(
        string? name = null,
        string? description = null,
        EquipmentType? type = null,
        string? ip = null,
        string? mac = null,
        string? tag = null,
        bool? rented = null,
        Guid? contractId = null)
    {
        Name = name ?? this.Name;
        Description = description ?? this.Description;
        Type = type ?? this.Type;
        Ip = ip ?? this.Ip;
        Mac = mac ?? this.Mac;
        Tag = tag ?? this.Tag;
        Rented = rented ?? this.Rented;
        ContractId = contractId ?? this.ContractId;
        UpdatedAt = DateTime.UtcNow;
    }
}