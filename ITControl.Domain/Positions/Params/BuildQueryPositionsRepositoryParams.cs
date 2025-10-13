using ITControl.Domain.Positions.Entities;

namespace ITControl.Domain.Positions.Params;

public class BuildQueryPositionsRepositoryParams
{
    public IQueryable<Position> Query { get; set; } = null!;
    public CountPositionsRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(out IQueryable<Position> query, out CountPositionsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}