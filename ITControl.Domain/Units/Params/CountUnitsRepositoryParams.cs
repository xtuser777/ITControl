namespace ITControl.Domain.Units.Params;

public record CountUnitsRepositoryParams : FindManyUnitsRepositoryParams
{
    public Guid? Id { get; set; } = null;
}
