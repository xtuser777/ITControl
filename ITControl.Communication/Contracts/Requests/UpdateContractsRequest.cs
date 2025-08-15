namespace ITControl.Communication.Contracts.Requests;

public class UpdateContractsRequest
{
    public string? Object { get; set; }
    public string? StartedAt { get; set; }
    public string? EndedAt { get; set; }
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}