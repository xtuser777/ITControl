using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record ExclusivePagesRepositoryParams : 
    FindManyPagesRepositoryParams, IExclusiveRepositoryParams
{
    public Guid ExcludeId { get; set; }
}