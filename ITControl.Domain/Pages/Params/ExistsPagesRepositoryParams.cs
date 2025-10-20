using ITControl.Domain.Shared.Params;

namespace ITControl.Domain.Pages.Params;

public record ExistsPagesRepositoryParams : 
    CountPagesRepositoryParams, IExistsRepositoryParams
{
}