namespace ITControl.Domain.Divisions.Params;

public record CountDivisionsRepositoryParams : 
    FindManyDivisionsRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
