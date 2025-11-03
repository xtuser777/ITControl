namespace ITControl.Domain.Positions.Params;

public class ExclusivePositionsParams 
    : FindManyPositionsParams
{
    public Guid ExcludeId { get; set; }
}