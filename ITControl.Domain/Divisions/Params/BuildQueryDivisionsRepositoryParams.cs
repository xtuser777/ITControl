using ITControl.Domain.Divisions.Entities;

namespace ITControl.Domain.Divisions.Params;

public class BuildQueryDivisionsRepositoryParams
{
    public IQueryable<Division> Query { get; set; } = null!;
    public CountDivisionsRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(
        out IQueryable<Division> query,
        out CountDivisionsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
