namespace ITControl.Domain.Positions.Params;

public record ExclusivePositionsParams 
    : FindManyPositionsParams
{
    public Guid ExcludeId { get; set; }
}