namespace ITControl.Domain.Contracts.Params;

public record CountContractsParams : FindManyContractsParams
{
    public Guid? Id { get; set; } = null;
}
