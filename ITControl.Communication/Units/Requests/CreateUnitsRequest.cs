namespace ITControl.Communication.Units.Requests;

public class CreateUnitsRequest
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string StreetName { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string AddressNumber { get; set; } = string.Empty;
}