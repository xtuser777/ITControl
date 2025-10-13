using ITControl.Domain.Pages.Entities;

namespace ITControl.Domain.Pages.Params;

public class BuildOrderByPagesRepositoryParams
{
    public IQueryable<Page> Query { get; set; } = null!;
    public FindManyPagesRepositoryParams Params { get; set; } = null!;

    public void Deconstruct(out IQueryable<Page> query, out FindManyPagesRepositoryParams @params)
    {
        query = Query;
        @params = Params;
    }
}