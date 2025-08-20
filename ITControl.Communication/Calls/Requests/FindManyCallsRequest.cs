using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Calls.Requests;
public class FindManyCallsRequest : PageableRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Reason { get; set; }
    public string? Status { get; set; }
    public Guid? UserId { get; set; }
    public Guid? LocationId { get; set; }
    public string? OrderByTitle { get; set; }
    public string? OrderByDescription { get; set; }
    public string? OrderByReason { get; set; }
    public string? OrderByStatus { get; set; }
    public string? OrderByUserId { get; set; }
    public string? OrderByLocationId { get; set; }
}
