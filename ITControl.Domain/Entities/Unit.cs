using ITControl.Domain.Validation;

namespace ITControl.Domain.Entities;

public sealed class Unit : Entity
{
    private string _name;
    private string _phone;
    private string _postalCode;
    private string _streetName;
    private string _neighborhood;
    private string _addressNumber;

    public Unit(
        string name,
        string phone,
        string postalCode,
        string streetName,
        string neighborhood,
        string addressNumber)
    {
        Id = Guid.NewGuid();
        _name = name;
        _phone = phone;
        _postalCode = postalCode;
        _streetName = streetName;
        _neighborhood = neighborhood;
        _addressNumber = addressNumber;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Name
    {
        get => _name;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(value),
                "Name can not be null or empty");
            DomainExceptionValidation.When(
                value.Length > 100,
                "Name can not be longer than 100 characters");
            DomainExceptionValidation.Throw();
            _name = value;
        }
    }

    public string Phone
    {
        get => _phone;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(value),
                "Phone can not be null or empty");
            DomainExceptionValidation.When(
                _phone.Length > 10,
                "Phone can not be longer than 10 characters");
            DomainExceptionValidation.When(
                _phone.Length < 10,
                "Phone can not be less than 10 characters");
            DomainExceptionValidation.Throw();
            _phone = value;
        }
    }

    public string PostalCode
    {
        get => _postalCode;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(value),
                "Postal can not be null or empty");
            DomainExceptionValidation.When(
                _postalCode.Length > 8,
                "Postal can not be longer than 8 characters");
            DomainExceptionValidation.When(
                _postalCode.Length < 8,
                "Postal can not be less than 8 characters");
            DomainExceptionValidation.Throw();
            _postalCode = value;
        }
    }

    public string StreetName
    {
        get => _streetName;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(value),
                "Street name can not be null or empty");
            DomainExceptionValidation.When(
                _streetName.Length > 100,
                "Street name can not be longer than 100 characters");
            DomainExceptionValidation.Throw();
            _streetName = value;
        }
    }

    public string Neighborhood
    {
        get => _neighborhood;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(value),
                "Neighborhood can not be null or empty");
            DomainExceptionValidation.When(
                _neighborhood.Length > 80,
                "Neighborhood can not be longer than 80 characters");
            DomainExceptionValidation.Throw();
            _neighborhood = value;
        }
    }

    public string AddressNumber
    {
        get => _addressNumber;
        set
        {
            DomainExceptionValidation.When(
                string.IsNullOrEmpty(value),
                "Address number can not be null or empty");
            DomainExceptionValidation.When(
                _addressNumber.Length > 5,
                "Address number can not be longer than 5 characters");
            DomainExceptionValidation.Throw();
            _addressNumber = value;
        }
    }

    public void Update(
        string? name,
        string? phone,
        string? postalCode,
        string? streetName,
        string? neighborhood,
        string? addressNumber)
    {
        _name = name ?? _name;
        _phone = phone ?? _phone;
        _postalCode = postalCode ?? _postalCode;
        _streetName = streetName ?? _streetName;
        _neighborhood = neighborhood ?? _neighborhood;
        _addressNumber = addressNumber ?? _addressNumber;
        UpdatedAt = DateTime.Now;
    }
}