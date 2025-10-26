namespace ITControl.Domain.Divisions.Params;

public record ExclusiveDivisionsParams :
    FindManyDivisionsParams
{
    public Guid ExcludeId { get; set; }
}
