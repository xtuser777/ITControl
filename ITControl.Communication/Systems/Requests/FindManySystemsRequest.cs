using ITControl.Communication.Shared.Requests;

namespace ITControl.Communication.Systems.Requests;

public class FindManySystemsRequest : PageableRequest
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? ImplementedAt { get; set; }
    public string? EndedAt { get; set; }
    public string? Own { get; set; }
    public string? ContractId { get; set; }
    public string? OrderByName { get; set; }
    public string? OrderByVersion { get; set; }
    public string? OrderByImplementedAt { get; set; }
    public string? OrderByEndedAt { get; set; }
    public string? OrderByOwn { get; set; }
    public string? OrderByContract { get; set; }
}