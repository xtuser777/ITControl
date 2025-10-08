using ITControl.Communication.Shared.Responses;

namespace ITControl.Communication.Calls.Responses;
public class FindManyCallsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TranslatableField Reason { get; set; } = null!;
    public TranslatableField Status { get; set; } = null!;
    public Guid UserId { get; set; }
    public Guid? EquipmentId { get; set; }
    public Guid? SystemId { get; set; }
}
