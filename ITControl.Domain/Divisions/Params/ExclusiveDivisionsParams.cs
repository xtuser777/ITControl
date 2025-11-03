namespace ITControl.Domain.Divisions.Params;

public class ExclusiveDivisionsParams :
    FindManyDivisionsParams
{
    public Guid ExcludeId { get; set; }
}
