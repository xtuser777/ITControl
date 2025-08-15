namespace ITControl.Communication.Contracts.Requests;

public class CreateContractsRequest
{
    public string Object { get; set; } = string.Empty;
    public string StartedAt { get; set; } = string.Empty;
    public string? EndedAt { get; set; }
    public IEnumerable<CreateContractsContactsRequest> Contacts { get; set; } = [];
}