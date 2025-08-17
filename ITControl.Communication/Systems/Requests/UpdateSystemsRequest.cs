namespace ITControl.Communication.Systems.Requests;

public class UpdateSystemsRequest
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? ImplementedAt { get; set; }
    public string? EndedAt { get; set; }
    public bool? Own { get; set; }
    public string? ContractId { get; set; }
}