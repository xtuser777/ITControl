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
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_name),
                "Name can not be null or empty");
            DomainExceptionValidation.When(
                _name.Length > 100,
                "Name can not be longer than 100 characters");
            _name = value;
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_email),
                "Email can not be null or empty");
            DomainExceptionValidation.When(
                _email.Length > 100,
                "Email can not be longer than 100 characters");
            _email = value;
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_phone),
                "Phone can not be null or empty");
            DomainExceptionValidation.When(
                _phone.Length > 10,
                "Phone can not be longer than 10 characters");
            _phone = value;
        }
    }

    public string Cellphone
    {
        get => _cellphone;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(_cellphone),
                "Cellphone can not be null or empty");
            DomainExceptionValidation.When(
                _cellphone.Length > 11,
                "Cellphone can not be longer than 11 characters");
            _cellphone = value;
        }
    }

    public Guid ContractId
    {
        get => _contractId;
        set
        {
            DomainExceptionValidation.When(
                _contractId == Guid.Empty,
                "Contract Id can not be empty");
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