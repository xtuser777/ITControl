namespace ITControl.Domain.Positions.Params;

public record CountPositionsParams : 
    FindManyPositionsParams
{
    public Guid? Id { get; set; }
}