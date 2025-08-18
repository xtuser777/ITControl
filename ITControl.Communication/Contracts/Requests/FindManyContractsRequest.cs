using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Contracts.Requests;

public class FindManyContractsRequest : PageableRequest
{
    public string? ObjectName { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public string? OrderByObjectName { get; set; }
    public string? OrderByStartedAt { get; set; }
    public string? OrderByEndedAt { get; set; }
}