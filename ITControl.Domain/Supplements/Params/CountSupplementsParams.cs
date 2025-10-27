namespace ITControl.Domain.Supplements.Params;

public record CountSupplementsParams : FindManySupplementsParams
{
    public Guid? Id { get; set; }
}