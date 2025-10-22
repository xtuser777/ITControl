namespace ITControl.Domain.SupplementsMovements.Params;

public record CountSupplementsMovementsRepositoryParams : 
    FindManySupplementsMovementsParams
{
    public Guid? Id { get; set; }
}