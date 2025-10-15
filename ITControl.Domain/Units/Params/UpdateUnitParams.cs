namespace ITControl.Domain.Units.Params;

public record UpdateUnitParams
{
    public string? Name { get; set; } = null;
    public string? Phone { get; set; } = null;
    public string? PostalCode { get; set; } = null;
    public string? StreetName { get; set; } = null;
    public string? Neighborhood { get; set; } = null;
    public string? AddressNumber { get; set; } = null;
}
