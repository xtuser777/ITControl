namespace ITControl.Communication.Contracts.Responses;

public class FindOneContractsResponse
{
    public string Id { get; set; } = string.Empty;
    public string Object { get; set; } = string.Empty;
    public string StartedAt { get; set; } = string.Empty;
    public string? EndedAt { get; set; }
    public IEnumerable<FindOneContractsContactsResponse> ContractsContacts { get; set; } = [];
}