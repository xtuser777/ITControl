using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Contracts.Requests;

public class FindManyContractsRequest : PageableRequest
{
    public string? Object { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public string? OrderByObject { get; set; }
    public string? OrderByStartedAt { get; set; }
    public string? OrderByEndedAt { get; set; }
}