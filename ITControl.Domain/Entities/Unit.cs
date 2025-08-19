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
                .When(value.Length < 10)
                .Property("Phone")
                .LengthMustBeGreaterThanOrEqualTo(10);
            DomainExceptionValidation
                .When(value.Length > 10)
                .Property("Phone")
                .LengthMustBeLessThanOrEqualTo(10);
            _phone = value;
        }
    }

    public string PostalCode
    {
        get => _postalCode;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("PostalCode")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length < 8)
                .Property("PostalCode")
                .LengthMustBeGreaterThanOrEqualTo(8);
            DomainExceptionValidation
                .When(value.Length > 8)
                .Property("PostalCode")
                .LengthMustBeLessThanOrEqualTo(8);
            _postalCode = value;
        }
    }

    public string StreetName
    {
        get => _streetName;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("StreetName")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 100)
                .Property("StreetName")
                .LengthMustBeLessThanOrEqualTo(100);
            _streetName = value;
        }
    }

    public string Neighborhood
    {
        get => _neighborhood;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("Neighborhood")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 80)
                .Property("Neighborhood")
                .LengthMustBeLessThanOrEqualTo(80);
            _neighborhood = value;
        }
    }

    public string AddressNumber
    {
        get => _addressNumber;
        set
        {
            DomainExceptionValidation
                .When(string.IsNullOrEmpty(value))
                .Property("AddressNumber")
                .MustNotBeEmpty();
            DomainExceptionValidation
                .When(value.Length > 5)
                .Property("AddressNumber")
                .LengthMustBeLessThanOrEqualTo(5);
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