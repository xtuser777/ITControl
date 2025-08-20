using ITControl.Communication.Shared.Responses;

namespace ITControl.Communication.Calls.Responses;
public class FindOneCallsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TranslatableField Reason { get; set; } = null!;
    public Guid CallStatusId { get; set; }
    public Guid UserId { get; set; }
    public Guid LocationId { get; set; }
    public Guid? EquipmentId { get; set; }
    public Guid? SystemId { get; set; }
    public FindOneCallsStatusResponse? CallStatus { get; set; }
    public FindOneCallsUserResponse? User { get; set; }
    public FindOneCallsLocationResponse? Location { get; set; }
    public FindOneCallsSystemResponse? System { get; set; }
    public FindOneCallsEquipmentResponse? Equipment { get; set; }
}
