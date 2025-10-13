using ITControl.Domain.Positions.Entities;

namespace ITControl.Domain.Positions.Params;

public class BuildOrderByPositionsRepositoryParams
{
    public IQueryable<Position> Query { get; set; } = null!;
    public FindManyPositionsRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(out IQueryable<Position> query, out FindManyPositionsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}