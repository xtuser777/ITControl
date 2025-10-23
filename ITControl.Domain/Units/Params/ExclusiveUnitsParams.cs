namespace ITControl.Domain.Units.Params;

public record ExclusiveUnitsParams : FindManyUnitsParams
{
    public Guid ExcludeId { get; set; }
}
