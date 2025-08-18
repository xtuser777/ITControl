namespace ITControl.Communication.Contracts.Requests;

public class UpdateContractsRequest
{
    public string? ObjectName { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}