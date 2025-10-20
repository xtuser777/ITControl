using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record CountPagesRepositoryParams : 
    FindManyPagesRepositoryParams, ICountRepositoryParams
{
    public Guid? Id { get; set; } = null;
}