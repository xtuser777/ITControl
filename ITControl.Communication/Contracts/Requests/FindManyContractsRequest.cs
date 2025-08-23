using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Contracts.Requests;

public class FindManyContractsRequest : PageableRequest
{
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public string? OrderByObjectName { get; set; }
    public string? OrderByStartedAt { get; set; }
    public string? OrderByEndedAt { get; set; }
}