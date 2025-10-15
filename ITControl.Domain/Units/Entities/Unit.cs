using ITControl.Domain.Shared.Entities;
using ITControl.Domain.Units.Params;

namespace ITControl.Domain.Units.Entities;

public sealed class Unit : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string AddressNumber { get; set; } = string.Empty;

    public Unit() { }

    public Unit(UnitParams @params)
    {
        Id = Guid.NewGuid();
        Name = @params.Name;
        Phone = @params.Phone;
        PostalCode = @params.PostalCode;
        StreetName = @params.StreetName;
        Neighborhood = @params.Neighborhood;
        AddressNumber = @params.AddressNumber;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }


    public void Update(UpdateUnitParams @params)
    {
        Name = @params.Name ?? Name;
        Phone = @params.Phone ?? Phone;
        PostalCode = @params.PostalCode ?? PostalCode;
        StreetName = @params.StreetName ?? StreetName;
        Neighborhood = @params.Neighborhood ?? Neighborhood;
        AddressNumber = @params.AddressNumber ?? AddressNumber;
        UpdatedAt = DateTime.Now;
    }
}