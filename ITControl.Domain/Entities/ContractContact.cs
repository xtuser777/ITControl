using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class ContractContact : Entity
{
    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _phone = string.Empty;
    private string _cellphone = string.Empty;
    private Guid _contractId;

    public ContractContact(string name, string email, string phone, string cellphone, Guid contractId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        Cellphone = cellphone;
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

    public string Email
    {
        get => _email;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Email")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("Email")
                .LengthMustBeLessThanOrEqualTo(100);
            _email = value;
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Phone")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 10)
                .Property("Phone")
                .LengthMustBeLessThanOrEqualTo(10);
            _phone = value;
        }
    }

    public string Cellphone
    {
        get => _cellphone;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Cellphone")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 11)
                .Property("Cellphone")
                .LengthMustBeLessThanOrEqualTo(11);
            _cellphone = value;
        }
    }

    public Guid ContractId
    {
        get => _contractId;
        set
        {
            DomainExceptionValidation
                .When(value == Guid.Empty)
                .Property("ContractId")
                .MustNotBeEmpty();
            _contractId = value;
        }
    }

    public void Update(string? name = null, string? email = null, string? phone = null, string? cellphone = null)
    {
        Name = name ?? Name;
        Email = email ?? Email;
        Phone = phone ?? Phone;
        Cellphone = cellphone ?? Cellphone;
        UpdatedAt = DateTime.Now;
    }

    public Contract? Contract { get; set; }
}