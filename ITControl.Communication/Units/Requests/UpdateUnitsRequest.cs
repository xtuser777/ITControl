namespace ITControl.Communication.Units.Requests;

public class UpdateUnitsRequest
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? PostalCode { get; set; }
    public string? StreetName { get; set; }
    public string? Neighborhood { get; set; }
    public string? AddressNumber { get; set; }
    public IEnumerable<CreateUnitsDepartmentsRequest>? Departments { get; set; }
    public IEnumerable<CreateUnitsDivisionsRequest>? Divisions { get; set; }
}