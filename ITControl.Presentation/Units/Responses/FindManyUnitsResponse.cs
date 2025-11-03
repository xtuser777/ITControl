namespace ITControl.Presentation.Units.Responses;

public class FindManyUnitsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? PostalCode { get; set; } = string.Empty;
    public string? StreetName { get; set; } = string.Empty;
    public string? Neighborhood { get; set; } = string.Empty;
    public string? AddressNumber { get; set; } = string.Empty;
}