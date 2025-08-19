using ITControl.Domain.Enums;
using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Equipment : Entity
{
    private string _name = string.Empty;
    private string _description = string.Empty;
    private string _ip = string.Empty;
    private string _mac = string.Empty;
    private string _tag = string.Empty;
    private bool _rented;
    private Guid? _contractId;

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
    
    public string Name 
    { 
        get => _name; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("name")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("name")
                .LengthMustBeLessThanOrEqualTo(100);
            _name = value;
        } 
    }
    public string Description 
    { 
        get => _description; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("description")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 255)
                .Property("description")
                .LengthMustBeLessThanOrEqualTo(255);
            _description = value;
        } 
    }
    public EquipmentType Type { get; set; }
    public string Ip 
    { 
        get => _ip; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("ip")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 15)
                .Property("ip")
                .LengthMustBeLessThanOrEqualTo(15);
            _ip = value;
        } 
    }
    public string Mac 
    { 
        get => _mac; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("mac")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 17)
                .Property("mac")
                .LengthMustBeLessThanOrEqualTo(17);
            _mac = value;
        } 
    }
    public string Tag 
    { 
        get => _tag; 
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("tag")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 15)
                .Property("tag")
                .LengthMustBeLessThanOrEqualTo(15);
            _tag = value;
        } 
    }
    public bool Rented 
    { 
        get => _rented; 
        set
        {
            DomainExceptionValidation
                .When(_contractId != null && value == false)
                .Property("rented")
                .MustNotBeEmpty();
            _rented = value;
        } 
    }
    public Guid? ContractId 
    { 
        get => _contractId; 
        set
        {
            DomainExceptionValidation
                .When(_rented == true && value == null)
                .Property("contractId")
                .MustNotBeNull();
            _contractId = value;
        } 
    }
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