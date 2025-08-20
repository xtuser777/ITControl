namespace ITControl.Communication.Calls.Requests;

public class CreateCallsRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid LocationId { get; set; }
    public Guid? EquipmentId { get; set; }
    public Guid? SystemId { get; set; }
}
