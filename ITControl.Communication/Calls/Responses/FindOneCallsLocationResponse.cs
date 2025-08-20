namespace ITControl.Communication.Calls.Responses;
public class FindOneCallsLocationResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
