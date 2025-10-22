namespace ITControl.Domain.Supplements.Params;

public record CountSupplementsRepositoryParams : FindManySupplementsParams
{
    public Guid? Id { get; set; }
}