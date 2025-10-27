namespace ITControl.Domain.SupplementsMovements.Params;

public record CountSupplementsMovementsParams : 
    FindManySupplementsMovementsParams
{
    public Guid? Id { get; set; }
}