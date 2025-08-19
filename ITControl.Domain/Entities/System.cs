using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public class System : Entity
{
    private string _name = string.Empty;
    private string _version = string.Empty;
    private DateOnly _implementedAt;
    private DateOnly? _endedAt;
    private bool _own;
    private Guid? _contractId;

    public System(
        string name,
        string version,
        DateOnly implementedAt,
        DateOnly? endedAt,
        bool own,
        Guid? contractId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Version = version;
        ImplementedAt = implementedAt;
        EndedAt = endedAt;
        Own = own;
        ContractId = contractId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Name
    {
        get => _name;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Name")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("Name")
                .LengthMustBeLessThanOrEqualTo(100);
            _name = value;
        }
    }

    public string Version
    {
        get => _version;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Version")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 15)
                .Property("Version")
                .LengthMustBeLessThanOrEqualTo(15);
            _version = value;
        }
    }

    public DateOnly ImplementedAt
    {
        get => _implementedAt;
        set
        {
            DomainExceptionValidation
                .When(value > DateOnly.FromDateTime(DateTime.Now))
                .Property("ImplementedAt")
                .DateMustNotBeGreaterThanCurrent();
            _implementedAt = value;
        }
    }

    public DateOnly? EndedAt
    {
        get => _endedAt;
        set
        {
            DomainExceptionValidation
                .When(value < _implementedAt)
                .Property("EndedAt")
                .DateMustNotBeLessThan(_implementedAt);
            _endedAt = value;
        }
    }

    public bool Own
    {
        get => _own;
        set
        {
            DomainExceptionValidation
                .When(_contractId != null && value == false)
                .Property("Own")
                .MustBeTrue();
            _own = value;
        }
    }

    public Guid? ContractId
    {
        get => _contractId;
        set
        {
            DomainExceptionValidation
                .When( _own == false || value == null)
                .Property("ContractId")
                .MustNotBeEmpty();
            _contractId = value;
        }
    }

    public void Update(
        string? name = null,
        string? version = null,
        DateOnly? implementedAt = null,
        DateOnly? endedAt = null,
        bool? own = null,
        Guid? contractId = null)
    {
        Name = name ?? Name;
        Version = version ?? Version;
        ImplementedAt = implementedAt ?? ImplementedAt;
        EndedAt = endedAt ?? EndedAt;
        Own = own ?? Own;
        ContractId = contractId ?? ContractId;
        UpdatedAt = DateTime.Now;
    }

    public Contract? Contract { get; set; }
}