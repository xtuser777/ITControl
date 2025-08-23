namespace ITControl.Communication.Contracts.Requests;

public class UpdateContractsRequest
{
    public string? ObjectName { get; set; }
    public DateOnly? StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}