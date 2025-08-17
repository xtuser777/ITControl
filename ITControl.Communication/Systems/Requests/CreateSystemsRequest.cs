namespace ITControl.Communication.Systems.Requests;

public class CreateSystemsRequest
{
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string ImplementedAt { get; set; } = string.Empty;
    public string? EndedAt { get; set; }
    public bool Own { get; set; }
    public string? ContractId { get; set; } = string.Empty;
}