using ITControl.Domain.Shared.Params2;

namespace ITControl.Domain.Units.Params;

public record UpdateUnitParams : UpdateEntityParams
{
    public string? Name { get; init; } = null;
    public string? Phone { get; init; } = null;
    public string? PostalCode { get; init; } = null;
    public string? StreetName { get; init; } = null;
    public string? Neighborhood { get; init; } = null;
    public string? AddressNumber { get; init; } = null;
}
