using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Units.Params;

public record OrderByUnitsParams : OrderByParams
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? PostalCode { get; set; }
    public string? StreetName { get; set; }
    public string? Neighborhood { get; set; }
    public string? AddressNumber { get; set; }
}
