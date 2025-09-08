using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Units.Entities;

public sealed class Unit : Entity
{
    public Unit(
        string name,
        string phone,
        string postalCode,
        string streetName,
        string neighborhood,
        string addressNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        Phone = phone;
        PostalCode = postalCode;
        StreetName = streetName;
        Neighborhood = neighborhood;
        AddressNumber = addressNumber;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public string Name { get; set; }
    public string Phone { get; set; }
    public string PostalCode { get; set; }
    public string StreetName { get; set; }
    public string Neighborhood { get; set; }
    public string AddressNumber { get; set; }

    public void Update(
        string? name,
        string? phone,
        string? postalCode,
        string? streetName,
        string? neighborhood,
        string? addressNumber)
    {
        Name = name ?? Name;
        Phone = phone ?? Phone;
        PostalCode = postalCode ?? PostalCode;
        StreetName = streetName ?? StreetName;
        Neighborhood = neighborhood ?? Neighborhood;
        AddressNumber = addressNumber ?? AddressNumber;
        UpdatedAt = DateTime.Now;
    }
}