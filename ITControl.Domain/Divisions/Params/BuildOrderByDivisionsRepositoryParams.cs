namespace ITControl.Domain.Divisions.Params;

public class BuildOrderByDivisionsRepositoryParams
{
    public IQueryable<Entities.Division> Query { get; set; } = null!;
    public FindManyDivisionsRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(
        out IQueryable<Entities.Division> query,
        out FindManyDivisionsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
