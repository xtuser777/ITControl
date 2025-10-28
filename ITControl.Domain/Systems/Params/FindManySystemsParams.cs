using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Systems.Params;

public record FindManySystemsParams : FindManyParams
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public DateOnly? ImplementedAt { get; set; }
    public DateOnly? EndedAt { get; set; }
    public bool? Own { get; set; }
    public Guid? ContractId { get; set; }
}
