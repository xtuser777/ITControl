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
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_name),
                "Name can not be empty");
            DomainExceptionValidation.When(
                _name.Length > 100,
                "Name can not be longer than 100 characters");
            _name = value;
        }
    }

    public string Version
    {
        get => _version;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_version),
                "Version can not be empty");
            DomainExceptionValidation.When(
                _version.Length > 15,
                "Version can not be longer than 15 characters");
            _version = value;
        }
    }

    public DateOnly ImplementedAt
    {
        get => _implementedAt;
        set
        {
            DomainExceptionValidation.When(
                _implementedAt > DateOnly.FromDateTime(DateTime.Now),
                "ImplementedAt can not be greater than current date");
            _implementedAt = value;
        }
    }

    public DateOnly? EndedAt
    {
        get => _endedAt;
        set
        {
            DomainExceptionValidation.When(
                _endedAt < _implementedAt,
                "EndedAt can not be less than current date");
            _endedAt = value;
        }
    }

    public bool Own
    {
        get => _own;
        set
        {
            DomainExceptionValidation.When(
                _contractId != null && _own == false,
                "Own can not be false when contract id is not null");
            _own = value;
        }
    }

    public Guid? ContractId
    {
        get => _contractId;
        set
        {
            DomainExceptionValidation.When(
                _own == false || _contractId == null,
                "Contract Id can not be empty");
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