namespace ITControl.Domain.Divisions.Params;

public record ExclusiveDivisionsRepositoryParams :
    FindManyDivisionsRepositoryParams
{
    public Guid ExcludeId { get; set; }
}
