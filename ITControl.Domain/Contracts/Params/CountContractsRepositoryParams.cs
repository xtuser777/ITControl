namespace ITControl.Domain.Contracts.Params;

public record CountContractsRepositoryParams : FindManyContractsRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
