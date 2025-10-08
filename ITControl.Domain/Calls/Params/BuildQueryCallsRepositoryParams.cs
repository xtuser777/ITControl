using ITControl.Domain.Calls.Entities;

namespace ITControl.Domain.Calls.Params;

public class BuildQueryCallsRepositoryParams
{
    public IQueryable<Call> Query { get; set; } = null!;
    public CountCallsRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(
        out IQueryable<Call> query,
        out CountCallsRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}
