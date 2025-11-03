namespace ITControl.Domain.Units.Params;

public class ExclusiveUnitsParams : FindManyUnitsParams
{
    public Guid ExcludeId { get; set; }
}
