using ITControl.Domain.Pages.Entities;

namespace ITControl.Domain.Pages.Params;

public class BuildQueryPagesRepositoryParams
{
    public IQueryable<Page> Query { get; set; } = null!;
    public CountPagesRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(out IQueryable<Page> query, out CountPagesRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}