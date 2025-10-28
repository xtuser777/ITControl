using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Units.Params;

public record UpdateUnitParams : UpdateEntityParams
{
    public string? Name { get; init; }
    public string? Phone { get; init; }
    public string? PostalCode { get; init; }
    public string? StreetName { get; init; }
    public string? Neighborhood { get; init; }
    public string? AddressNumber { get; init; }
}
