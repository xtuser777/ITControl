namespace ITControl.Communication.Contracts.Requests;

public class CreateContractsRequest
{
    public string ObjectName { get; set; } = string.Empty;
    public DateOnly StartedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}