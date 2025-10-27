namespace ITControl.Domain.Units.Params;

public record CountUnitsParams : FindManyUnitsParams
{
    public Guid? Id { get; set; }
}
