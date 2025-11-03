using ITControl.Domain.Shared.Entities;

namespace ITControl.Domain.Units.Props;

public class UnitProps : Entity
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? PostalCode { get; set; }
    public string? StreetName { get; set; }
    public string? Neighborhood { get; set; }
    public string? AddressNumber { get; set; }
}