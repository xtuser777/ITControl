using ITControl.Domain.Calls.Entities;

namespace ITControl.Domain.Calls.Params;

public class BuildOrderByCallsRepositoryParams
{
    public IQueryable<Call> Query { get; set; } = null!;
    public FindManyCallsRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(
        out IQueryable<Call> query,
        out FindManyCallsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
