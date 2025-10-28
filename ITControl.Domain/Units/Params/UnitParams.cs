using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Units.Params;

public record UnitParams : EntityParams
{
    public string Name { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public string StreetName { get; init; } = string.Empty;
    public string Neighborhood { get; init; } = string.Empty;
    public string AddressNumber { get; init; } = string.Empty;
}
