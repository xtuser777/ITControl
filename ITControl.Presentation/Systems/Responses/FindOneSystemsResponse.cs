namespace ITControl.Presentation.Systems.Responses;

public class FindOneSystemsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public DateOnly ImplementedAt { get; set; } 
    public DateOnly? EndedAt { get; set; }
    public bool Own { get; set; }
    public Guid? ContractId { get; set; }
    public FindOneSystemsContractResponse? Contract { get; set; }
}