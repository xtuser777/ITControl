namespace ITControl.Communication.Systems.Requests;

public class UpdateSystemsRequest
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public DateOnly? ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public bool? Own { get; set; }
    public Guid? ContractId { get; set; }
}